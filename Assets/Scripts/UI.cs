using System.Collections;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text text;
    [SerializeField] float panelDelay = 1;

    private void Awake()
    {
        panel.SetActive(false);
    }

    public void PanelManager(string Text)
    {
        text.text = Text;
        panel.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(TimeActiv());
    }

    IEnumerator TimeActiv()
    {
        yield return new WaitForSeconds(panelDelay);
        panel.SetActive(false);
        StopAllCoroutines();
    }
}
