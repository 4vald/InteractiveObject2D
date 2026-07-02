using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI interactionText;

    private void Start()
    {
        Hide();
    }

    public void Show(string text)
    {
        panel.SetActive(true);
        interactionText.text = text;
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}