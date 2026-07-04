using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractableBase, ISaveable
{
    [SerializeField] private DoorData data;
    [SerializeField] private string saveId;

    private Animator animator;
    private bool isOpen;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        Toggle();
    }

    public override string GetInteractionText()
    {
        return isOpen
            ? data.GetCloseText()
            : data.GetOpenText();
    }

    public void Open()
    {
        if (isOpen)
            return;

        isOpen = true;
        animator.SetBool("Open", true);
        AudioManager.Instance?.PlayDoorOpen();

        AutoSave();
    }

    public void Close()
    {
        if (!isOpen)
            return;

        isOpen = false;
        animator.SetBool("Open", false);
        AudioManager.Instance?.PlayDoorClose();

        AutoSave();
    }

    public void Toggle()
    {
        if (isOpen)
            Close();
        else
            Open();
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
        return isOpen;
    }

    public void RestoreState(bool state)
    {
        isOpen = state;
        animator.SetBool("Open", isOpen);
    }
}