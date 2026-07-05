using UnityEngine;

public class NPC : InteractableBase
{
    [Header("Dialogues")]
    [SerializeField] private string[] russianDialogue;
    [SerializeField] private string[] englishDialogue;

    public override void Interact()
    {
        if (DialogueManager.Instance == null)
            return;

        AudioManager.Instance?.PlayNPC();

        string[] dialogue =
            LocalizationManager.Instance.CurrentLanguage == Language.Russian
            ? russianDialogue
            : englishDialogue;

        if (!DialogueManager.Instance.IsDialogueOpen)
        {
            DialogueManager.Instance.StartDialogue(dialogue);
        }
        else
        {
            DialogueManager.Instance.NextLine();
        }
    }

    public override string GetInteractionText()
    {
        return LocalizationManager.Instance.CurrentLanguage == Language.Russian
            ? "Поговорить"
            : "Talk";
    }
}