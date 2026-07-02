using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    public bool IsOpen => panel.activeSelf;

    private void Start()
    {
        Hide();
    }

    public void Show(string text)
    {
        panel.SetActive(true);
        dialogueText.text = text;
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}