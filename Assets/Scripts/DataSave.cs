using System;
using UnityEngine;

[Serializable]
public class DataSave
{
    public bool level1Completed = false;
    public bool level2Completed = false;
    public bool level3Completed = false;
    public bool level4Completed = false;
    public bool level5Completed = false;

    public static DataSave SerializeData(string jsonString)
    {
        return JsonUtility.FromJson<DataSave>(jsonString);
    }

    public string DeserializeData()
    {
        return JsonUtility.ToJson(this, true);
    }
}
