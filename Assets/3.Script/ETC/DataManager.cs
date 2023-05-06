using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RankingData
{
    public List<int> Ranking;
    public List<string> name;
    public List<float> time;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;

    RankingData rankingdata = new RankingData();

    string path;
    string fileName = "RankingData.json";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        path = Application.dataPath + "/Resources/";

        rankingdata.Ranking = new List<int>();
        rankingdata.name = new List<string>();
        rankingdata.time = new List<float>();
    }

    public void SaveData(string name, float time)
    {
        string data;

        /*rankingdata.name.Add(name);
        rankingdata.time.Add(time);*/

        data = JsonUtility.ToJson(rankingdata);
        File.WriteAllText(path + fileName, data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + fileName);
        for (int i = 0; i < 11; i++)
        {
            rankingdata = JsonUtility.FromJson<RankingData>(data);
        }
    }

    public RankingData ShuffleList(RankingData rankingdata)
    {

        return rankingdata;
    }
}
