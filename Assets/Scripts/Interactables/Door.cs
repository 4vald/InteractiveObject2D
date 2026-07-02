using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractableBase
{
    [SerializeField] private DoorData data;

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
    }

    public void Close()
    {
        if (!isOpen)
            return;

        isOpen = false;
        animator.SetBool("Open", false);
    }

    public void Toggle()
    {
        if (isOpen)
            Close();
        else
            Open();
    }
}