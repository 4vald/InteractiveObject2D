using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Chest : InteractableBase, ISaveable
{
    [SerializeField] private string closedText = "Открыть сундук";
    [SerializeField] private string openedText = "Сундук пуст";
    [SerializeField] private string saveId;

    private Animator animator;
    private bool isOpened;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (isOpened)
            return;

        isOpened = true;
        animator.SetBool("Open", true);

        AutoSave();
    }

    public override string GetInteractionText()
    {
        return isOpened ? openedText : closedText;
    }

    public override bool CanInteract()
    {
        return !isOpened;
    }

    private void AutoSave()
    {
        if (GameManager.Instance == null)
            return;

        GameManager.Instance.SaveGame();
    }

    public string GetId()
    {
        return saveId;
    }

    public bool CaptureState()
    {
        return isOpened;
    }

    public void RestoreState(bool state)
    {
        isOpened = state;
        animator.SetBool("Open", isOpened);
    }
}