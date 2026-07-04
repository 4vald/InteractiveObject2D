public interface ISaveable
{
    string GetId();

    bool CaptureState();

    void RestoreState(bool state);
}