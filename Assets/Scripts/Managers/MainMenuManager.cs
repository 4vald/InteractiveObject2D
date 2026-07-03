using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Save.Managers;

public class MainMenuManager : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private GameObject menuRU;
    [SerializeField] private GameObject menuEN;

    [Header("Language")]
    [SerializeField] private GameObject languageRU;
    [SerializeField] private GameObject languageEN;

    [Header("New Game")]
    [SerializeField] private GameObject newGameRU;
    [SerializeField] private GameObject newGameEN;

    [Header("Load Game")]
    [SerializeField] private GameObject loadGameRU;
    [SerializeField] private GameObject loadGameEN;

    [Header("Input")]
    [SerializeField] private TMP_InputField inputRU;
    [SerializeField] private TMP_InputField inputEN;

    [Header("Managers")]
    [SerializeField] private SaveManager saveManager;

    private bool isRussian = true;
    private int selectedSlot = 0;

    private void Start()
    {
        ShowMainMenu();
    }

    private void HideAll()
    {
        menuRU.SetActive(false);
        menuEN.SetActive(false);

        languageRU.SetActive(false);
        languageEN.SetActive(false);

        newGameRU.SetActive(false);
        newGameEN.SetActive(false);

        loadGameRU.SetActive(false);
        loadGameEN.SetActive(false);
    }

    public void ShowMainMenu()
    {
        HideAll();

        if (isRussian)
            menuRU.SetActive(true);
        else
            menuEN.SetActive(true);
    }

    public void OpenLanguage()
    {
        HideAll();

        if (isRussian)
            languageRU.SetActive(true);
        else
            languageEN.SetActive(true);
    }

    public void OpenNewGame()
    {
        HideAll();

        selectedSlot = 0;

        if (isRussian)
            newGameRU.SetActive(true);
        else
            newGameEN.SetActive(true);
    }

    public void OpenLoadGame()
    {
        HideAll();

        if (isRussian)
            loadGameRU.SetActive(true);
        else
            loadGameEN.SetActive(true);
    }

    public void Back()
    {
        ShowMainMenu();
    }

    public void SetRussian()
    {
        isRussian = true;
        ShowMainMenu();
    }

    public void SetEnglish()
    {
        isRussian = false;
        ShowMainMenu();
    }

    public void SelectSlot1()
    {
        selectedSlot = 1;
        Debug.Log("Выбран слот 1");
    }

    public void SelectSlot2()
    {
        selectedSlot = 2;
        Debug.Log("Выбран слот 2");
    }

    public void SelectSlot3()
    {
        selectedSlot = 3;
        Debug.Log("Выбран слот 3");
    }

    public void CreateSave()
    {
        if (selectedSlot == 0)
        {
            Debug.Log("Выберите слот.");
            return;
        }

        string saveName = isRussian ? inputRU.text : inputEN.text;

        if (string.IsNullOrWhiteSpace(saveName))
        {
            Debug.Log("Введите название сохранения.");
            return;
        }

        saveManager.CreateSave(selectedSlot, saveName);

        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}