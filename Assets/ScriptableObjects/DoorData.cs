using UnityEngine;

[CreateAssetMenu(fileName = "DoorData", menuName = "Game/Door Data")]
public class DoorData : ScriptableObject
{
    public float openAngle = 90f;

    [Header("Russian")]
    public string openTextRU = "Открыть дверь";
    public string closeTextRU = "Закрыть дверь";

    [Header("English")]
    public string openTextEN = "Open Door";
    public string closeTextEN = "Close Door";

    public string GetOpenText()
    {
        return LocalizationManager.Instance.CurrentLanguage == Language.Russian
            ? openTextRU
            : openTextEN;
    }

    public string GetCloseText()
    {
        return LocalizationManager.Instance.CurrentLanguage == Language.Russian
            ? closeTextRU
            : closeTextEN;
    }
}