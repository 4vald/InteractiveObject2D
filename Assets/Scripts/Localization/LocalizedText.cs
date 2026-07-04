using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LocalizedText : MonoBehaviour
{
    [Header("Текст")]
    [TextArea]
    [SerializeField] private string russian;

    [TextArea]
    [SerializeField] private string english;

    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        if (LocalizationManager.Instance != null)
        {
            LocalizationManager.Instance.OnLanguageChanged += UpdateLanguage;
        }

        UpdateLanguage();
    }

    private void OnDisable()
    {
        if (LocalizationManager.Instance != null)
        {
            LocalizationManager.Instance.OnLanguageChanged -= UpdateLanguage;
        }
    }

    private void UpdateLanguage()
    {
        if (LocalizationManager.Instance == null)
            return;

        switch (LocalizationManager.Instance.CurrentLanguage)
        {
            case Language.Russian:
                text.text = russian;
                break;

            case Language.English:
                text.text = english;
                break;
        }
    }
}