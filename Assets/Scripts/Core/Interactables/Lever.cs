using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Lever : InteractableBase, ISaveable
{
    [Header("Lever")]


    [SerializeField] private string saveId;

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
        AudioManager.Instance?.PlayLever();

        if (isActivated)
            onLeverActivated.Invoke();
        else
            onLeverDeactivated.Invoke();

        AutoSave();
    }

    public override string GetInteractionText()
    {
        if (LocalizationManager.Instance.CurrentLanguage == Language.Russian)
            return isActivated ? "Вернуть рычаг" : "Дернуть рычаг";

        return isActivated ? "Reset Lever" : "Pull Lever";
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
        return isActivated;
    }

    public void RestoreState(bool state)
    {
        isActivated = state;

        animator.SetBool("IsOn", isActivated);

        if (isActivated)
            onLeverActivated.Invoke();
        else
            onLeverDeactivated.Invoke();
    }
}