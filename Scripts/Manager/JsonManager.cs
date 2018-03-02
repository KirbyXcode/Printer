using UnityEngine;
using System;
using System.IO;

public class JsonManager : ManagerBase
{
    public static JsonManager Instance;

    private string path;
    private Data data;

    private void Awake()
    {
        Instance = this;

        Add(0, this);

        GetRecordFromJson();
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case 0:
                SetRecordToJson(message as Data);
                break;
        }
    }

    public Data GetData()
    {
        return data;
    }

    private void SetRecordToJson(Data data)
    {
        string json = JsonUtility.ToJson(data);

        if (File.Exists(path))
        {
            File.WriteAllText(path, json);
        }
    }

    public void GetRecordFromJson()
    {
        path = Application.streamingAssetsPath + "/data.json";

        string dataStr = null;

        if (File.Exists(path))
        {
            dataStr = File.ReadAllText(path);
        }

        data = JsonUtility.FromJson<Data>(dataStr);
    }
}


[Serializable]
public class Data
{
    public int visitorIndex;
    public string printerName;
}

