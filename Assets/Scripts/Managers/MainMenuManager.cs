using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Save.Managers;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject newGamePanel;
    [SerializeField] private GameObject loadGamePanel;
    [SerializeField] private GameObject languagePanel;

    [Header("Input")]
    [SerializeField] private TMP_InputField saveNameInput;

    [Header("Managers")]
    [SerializeField] private SaveManager saveManager;

    private int selectedSlot;

    private void Start()
    {
        ShowMainMenu();
    }

    private void HideAll()
    {
        menuPanel.SetActive(false);
        newGamePanel.SetActive(false);
        loadGamePanel.SetActive(false);
        languagePanel.SetActive(false);
    }

    public void ShowMainMenu()
    {
        HideAll();
        menuPanel.SetActive(true);
    }

    public void OpenNewGame()
    {
        AudioManager.Instance?.PlayButton();

        HideAll();

        selectedSlot = 0;

        newGamePanel.SetActive(true);
    }

    public void OpenLoadGame()
    {
        AudioManager.Instance?.PlayButton();

        HideAll();

        loadGamePanel.SetActive(true);
    }

    public void OpenLanguage()
    {
        AudioManager.Instance?.PlayButton();

        HideAll();

        languagePanel.SetActive(true);
    }

    public void Back()
    {
        AudioManager.Instance?.PlayButton();

        ShowMainMenu();
    }

    public void SetRussian()
    {
        AudioManager.Instance?.PlayButton();

        LocalizationManager.Instance.SetLanguage(Language.Russian);
    }

    public void SetEnglish()
    {
        AudioManager.Instance?.PlayButton();

        LocalizationManager.Instance.SetLanguage(Language.English);
    }

    public void SelectSlot1()
    {
        AudioManager.Instance?.PlayButton();

        selectedSlot = 1;
    }

    public void SelectSlot2()
    {
        AudioManager.Instance?.PlayButton();

        selectedSlot = 2;
    }

    public void SelectSlot3()
    {
        AudioManager.Instance?.PlayButton();

        selectedSlot = 3;
    }

    public void CreateSave()
    {
        AudioManager.Instance?.PlayButton();

        if (selectedSlot == 0)
        {
            Debug.Log("Выберите слот.");
            return;
        }

        if (string.IsNullOrWhiteSpace(saveNameInput.text))
        {
            Debug.Log("Введите название сохранения.");
            return;
        }

        saveManager.CreateSave(selectedSlot, saveNameInput.text);
        saveManager.SetCurrentSlot(selectedSlot);

        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {
        AudioManager.Instance?.PlayButton();

        Application.Quit();
    }
}