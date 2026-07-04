using UnityEngine;

public class NPC : InteractableBase
{
    [SerializeField]
    private string[] dialogue;

    public override void Interact()
    {
        if (DialogueManager.Instance == null)
            return;

        AudioManager.Instance?.PlayNPC();

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
        return "Поговорить";
    }
}