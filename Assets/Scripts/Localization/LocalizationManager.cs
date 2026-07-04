using System;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;

    public Language CurrentLanguage { get; private set; }

    public event Action OnLanguageChanged;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        CurrentLanguage = (Language)PlayerPrefs.GetInt("Language", 0);
    }

    public void SetLanguage(Language language)
    {
        CurrentLanguage = language;

        PlayerPrefs.SetInt("Language", (int)language);
        PlayerPrefs.Save();

        OnLanguageChanged?.Invoke();
    }
}