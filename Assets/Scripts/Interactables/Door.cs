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
        return isOpen ? data.closeText : data.openText;
    }

    public void Open()
    {
        if (isOpen)
            return;

        isOpen = true;
        animator.SetBool("Open", true);

        AutoSave();
    }

    public void Close()
    {
        if (!isOpen)
            return;

        isOpen = false;
        animator.SetBool("Open", false);

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
        if (Save.Managers.SaveManager.Instance == null)
            return;

        if (Save.Managers.SaveManager.Instance.CurrentSlot == -1)
            return;

        Debug.Log("Автосохранение двери");
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