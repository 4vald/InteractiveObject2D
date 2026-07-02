using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private DialogueUI dialogueUI;

    private string[] currentDialogue;
    private int currentIndex;

    public bool IsDialogueOpen => dialogueUI.IsOpen;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartDialogue(string[] dialogue)
    {
        currentDialogue = dialogue;
        currentIndex = 0;

        dialogueUI.Show(currentDialogue[currentIndex]);
    }

    public void NextLine()
    {
        if (currentDialogue == null)
            return;

        currentIndex++;

        if (currentIndex >= currentDialogue.Length)
        {
            EndDialogue();
            return;
        }

        dialogueUI.Show(currentDialogue[currentIndex]);
    }

    public void EndDialogue()
    {
        currentDialogue = null;
        currentIndex = 0;

        dialogueUI.Hide();
    }
}