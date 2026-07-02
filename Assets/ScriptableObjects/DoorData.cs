using UnityEngine;

[CreateAssetMenu(fileName = "DoorData", menuName = "Game/Door Data")]
public class DoorData : ScriptableObject
{
    public float openAngle = 90f;

    public string openText = "Открыть дверь";

    public string closeText = "Закрыть дверь";
}