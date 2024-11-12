using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] UI ui;

    private Vector2 _startPos;
    private Vector2 _startPos1;
    private Vector2 _startPos2;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            SwipeRightRecognition();
        }

        if (Input.touchCount == 2)
        {
            ZoomRecognition();
        }
    }

    private void SwipeRightRecognition()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            _startPos = touch.position;
        }

        if (touch.deltaPosition.x < 0)
        {
            _startPos = touch.position;
        }

        if (touch.phase == TouchPhase.Ended)
        {
            if (touch.position.x > _startPos.x + 100 && touch.position.y > _startPos.y - 50 && touch.position.y < _startPos.y + 50)
            {
                _startPos = touch.position;
                ui.PanelManager("right");
            }
        }
    }

    private void ZoomRecognition()
    {
        Touch touch1 = Input.GetTouch(0), touch2 = Input.GetTouch(1);

        if (touch2.phase == TouchPhase.Began)
        {
            _startPos1 = touch1.position;
            _startPos2 = touch2.position;

            float r = Vector2.Distance(_startPos1, _startPos2);
        }

        if (Vector2.Distance(_startPos1, _startPos2) * 1.1f < Vector2.Distance(touch1.position, touch2.position))
        {
            if (touch1.deltaPosition.x * touch2.deltaPosition.x <= 0 && touch1.deltaPosition.y * touch2.deltaPosition.y <= 0)
            {
                ui.PanelManager("zoom");
            }
        }

    }
}
