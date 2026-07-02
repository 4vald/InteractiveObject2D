using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Chest : InteractableBase
{
    [SerializeField] private string closedText = "Открыть сундук";
    [SerializeField] private string openedText = "Сундук пуст";

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
    }

    public override string GetInteractionText()
    {
        return isOpened ? openedText : closedText;
    }

    public override bool CanInteract()
    {
        return !isOpened;
    }
}