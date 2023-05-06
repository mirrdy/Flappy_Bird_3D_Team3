using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RankingData
{
    public int Ranking = 1;
    public string name = "¤±¤±¤±";
    public float time = 0;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;

    RankingData[] rankingdata = new RankingData[11];

    string path;
    string fileName = "RankingData";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        path = Application.dataPath + "/";
    }

    public void Start()
    {
        SaveData();
        LoadData();
    }

    public void SaveData()
    {
        string[] data = new string[11];
        for (int i = 0; i < rankingdata.Length; i++)
        {
            data[i] = JsonUtility.ToJson(rankingdata[i]);
            File.WriteAllText(path + fileName, data[i]);
        }
        print(path);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + fileName);
        for (int i = 0; i < rankingdata.Length; i++)
        {
            rankingdata[i] = JsonUtility.FromJson<RankingData>(data);
        }
        print(data);
    }
}
