using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int saveLocation;
    public int missionComplete;
    public int Elytherium;
    public int moral;
    public bool river = true;

    public int timesaved;

     public System.Collections.Generic.List<string> destroyedObjects = new System.Collections.Generic.List<string>();
}

