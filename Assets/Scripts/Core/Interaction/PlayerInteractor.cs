using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 2f;
    [SerializeField] private LayerMask interactableLayer;

    [Header("UI")]
    [SerializeField] private InteractionUI interactionUI;

    private PlayerInputActions inputActions;

    private IInteractable currentInteractable;
    private OutlineTarget currentOutline;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        if (DialogueManager.Instance != null &&
            DialogueManager.Instance.IsDialogueOpen)
        {
            interactionUI.Hide();

            if (inputActions.Player.Interact.WasPressedThisFrame())
            {
                DialogueManager.Instance.NextLine();
            }

            return;
        }

        FindInteractable();

        if (currentInteractable != null)
        {
            interactionUI.Show("E - " + currentInteractable.GetInteractionText());

            if (inputActions.Player.Interact.WasPressedThisFrame())
            {
                currentInteractable.Interact();
            }
        }
        else
        {
            interactionUI.Hide();

            if (DialogueManager.Instance != null)
            {
                DialogueManager.Instance.EndDialogue();
            }
        }
    }

    private void FindInteractable()
    {
        if (currentOutline != null)
        {
            currentOutline.DisableOutline();
            currentOutline = null;
        }

        currentInteractable = null;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(
            transform.position,
            interactionRadius,
            interactableLayer);

        foreach (Collider2D collider in colliders)
        {
            IInteractable interactable = collider.GetComponent<IInteractable>();

            if (interactable == null)
                continue;

            currentInteractable = interactable;

            currentOutline = collider.GetComponent<OutlineTarget>();

            if (currentOutline != null)
                currentOutline.EnableOutline();

            return;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(
            transform.position,
            interactionRadius);
    }
}