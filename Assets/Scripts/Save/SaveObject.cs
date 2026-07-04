using UnityEngine;

public abstract class SaveObject : MonoBehaviour
{
    [Header("Save")]
    [SerializeField] private string objectId;

    public string ObjectId => objectId;

    public abstract object CaptureState();

    public abstract void RestoreState(object state);
}