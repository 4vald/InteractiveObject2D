using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private PlayerInputActions input;

    private bool isPaused;

    private void Awake()
    {
        input = new PlayerInputActions();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        if (input.Player.Pause.WasPressedThisFrame())
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("PauseGame");

        AudioManager.Instance?.PlayButton();

        pausePanel.SetActive(true);

        Debug.Log(pausePanel.activeSelf);

        Time.timeScale = 0f;

        isPaused = true;
    }

    public void ResumeGame()
    {
        AudioManager.Instance?.PlayButton();

        pausePanel.SetActive(false);

        Time.timeScale = 1f;

        isPaused = false;
    }

    public void SaveGame()
    {
        AudioManager.Instance?.PlayButton();

        GameManager.Instance.SaveGame();
    }

    public void ExitToMenu()
    {
        AudioManager.Instance?.PlayButton();

        GameManager.Instance.SaveGame();

        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}