using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Lever : InteractableBase
{
    [Header("Lever")]
    [SerializeField] private string enableText = "Дернуть рычаг";
    [SerializeField] private string disableText = "Вернуть рычаг";

    [SerializeField] private UnityEvent onLeverActivated;
    [SerializeField] private UnityEvent onLeverDeactivated;

    private Animator animator;
    private bool isActivated;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        isActivated = !isActivated;

        animator.SetBool("IsOn", isActivated);

        if (isActivated)
            onLeverActivated.Invoke();
        else
            onLeverDeactivated.Invoke();
    }

    public override string GetInteractionText()
    {
        return isActivated ? disableText : enableText;
    }
}