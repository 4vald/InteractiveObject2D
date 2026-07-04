using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public int Slot;

    public string SaveName;

    public string CreatedAt;

    public string LastPlayedAt;

    public List<ObjectState> Objects = new();
}

[Serializable]
public class ObjectState
{
    public string Id;
    public bool State;
}