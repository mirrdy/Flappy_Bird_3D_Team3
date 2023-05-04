using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RankingData
{
    public int Ranking;
    public string name;
    public float time;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;

    RankingData rankingdata = new RankingData();

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

        path = Application.persistentDataPath + "/";
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
        rankingdata = JsonUtility.FromJson<RankingData>(data);
        print(data);
    }
}
