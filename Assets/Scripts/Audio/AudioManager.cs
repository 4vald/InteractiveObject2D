using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource audioSource;

    [Header("Sounds")]
    [SerializeField] private AudioClip doorOpen;
    [SerializeField] private AudioClip doorClose;
    [SerializeField] private AudioClip chestOpen;
    [SerializeField] private AudioClip lever;
    [SerializeField] private AudioClip npc;
    [SerializeField] private AudioClip button;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayDoorOpen()
    {
        audioSource.PlayOneShot(doorOpen);
    }

    public void PlayDoorClose()
    {
        audioSource.PlayOneShot(doorClose);
    }

    public void PlayChestOpen()
    {
        audioSource.PlayOneShot(chestOpen);
    }

    public void PlayLever()
    {
        audioSource.PlayOneShot(lever);
    }

    public void PlayNPC()
    {
        audioSource.PlayOneShot(npc);
    }

    public void PlayButton()
    {
        audioSource.PlayOneShot(button);
    }
}