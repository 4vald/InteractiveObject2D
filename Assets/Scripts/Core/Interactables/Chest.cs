using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Chest : InteractableBase, ISaveable
{

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
        AudioManager.Instance?.PlayChestOpen();

        AutoSave();
    }

    public override string GetInteractionText()
    {
        if (LocalizationManager.Instance.CurrentLanguage == Language.Russian)
            return isOpened ? "Сундук пуст" : "Открыть сундук";

        return isOpened ? "Chest is empty" : "Open Chest";
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