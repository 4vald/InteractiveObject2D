using UnityEngine;
using Save.Managers;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private SaveManager saveManager;

    public SaveManager SaveManager => saveManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (saveManager == null)
            saveManager = FindFirstObjectByType<SaveManager>();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "MainScene")
            return;

        if (saveManager == null)
            saveManager = FindFirstObjectByType<SaveManager>();

        if (saveManager != null)
            LoadGame();
    }

    public void SaveGame()
    {
        if (saveManager != null)
            saveManager.SaveWorld();
    }

    public void LoadGame()
    {
        if (saveManager != null)
            saveManager.LoadWorld();
    }
}