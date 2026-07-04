using UnityEngine;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    public abstract void Interact();

    public abstract string GetInteractionText();

    public virtual bool CanInteract()
    {
        return true;
    }
}