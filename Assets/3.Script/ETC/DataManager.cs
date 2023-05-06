using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RankingData
{
    public int Ranking = 1;
    public string name = "けけけ";
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

        path = Application.dataPath + "Saves/";

        for (int i = 0; i < rankingdata.Length; i++)
        {
            rankingdata[i].Ranking = 1;
            rankingdata[i].name = "けけけ";
            rankingdata[i].time = 0f;
        }
    }

    public void Start()
    {
        SaveData();
        LoadData();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(rankingdata);
        File.WriteAllText(path + fileName, data);
        print(path);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + fileName);
        rankingdata[1] = JsonUtility.FromJson<RankingData>(data);
        print(data);
    }
}
