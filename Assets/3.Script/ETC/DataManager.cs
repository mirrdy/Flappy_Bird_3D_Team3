using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class RankingData
{
    public int[] Ranking = new int[11];
    public string[] name = new string[11];
    public float[] time = new float[11];
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;

    RankingData rankingdata = new RankingData();

    [SerializeField] private Text NameText;
    [SerializeField] private Text ScoreText;

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

        path = Application.dataPath + "/Resources/";

        LoadData();
    }

    public void SaveData()
    {
        UpdateRank();

        string data = JsonUtility.ToJson(rankingdata);
        File.WriteAllText(path + fileName + ".json", data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + fileName + ".json");
        rankingdata = JsonUtility.FromJson<RankingData>(data);
    }

    public RankingData UpdateRank()
    {
        RankingData ranking = new RankingData();

        for (int i = 0; i < rankingdata.Ranking.Length; i++)
        {
            rankingdata.Ranking[i] = 1;
            for (int j = 0; j < rankingdata.Ranking.Length; j++)
            {
                if (rankingdata.time[i] < rankingdata.time[j] || rankingdata.time[i] == 0f)
                {
                    rankingdata.Ranking[i]++;
                }
            }
        }

        for (int i = 0; i < rankingdata.Ranking.Length; i++)
        {
            ranking.Ranking[i] = rankingdata.Ranking[i];
            ranking.name[i] = rankingdata.name[i];
            ranking.time[i] = rankingdata.time[i];
        }

        for (int i = 0; i < rankingdata.Ranking.Length; i++)
        {
            
            for (int j = 0; j < rankingdata.Ranking.Length; j++)
            {
                if(ranking.Ranking[j] == i + 1)
                {
                    rankingdata.Ranking[i] = ranking.Ranking[j];
                    rankingdata.name[i] = ranking.name[j];
                    rankingdata.time[i] = ranking.time[j];
                    rankingdata.name[j] = "  ";
                    rankingdata.time[j] = 0f;
                    continue;
                }
            }
        }
        return rankingdata;
    }

    public void Print()
    {
        LoadData();

        NameText.text = rankingdata.name[0] + "\n" + "\n" +
                        rankingdata.name[1] + "\n" + "\n" +
                        rankingdata.name[2] + "\n" + "\n" +
                        rankingdata.name[3] + "\n" + "\n" +
                        rankingdata.name[4] + "\n" + "\n" +
                        rankingdata.name[5] + "\n" + "\n" +
                        rankingdata.name[6] + "\n" + "\n" +
                        rankingdata.name[7] + "\n" + "\n" +
                        rankingdata.name[8] + "\n" + "\n" +
                        rankingdata.name[9] + "\n" + "\n" +
                        rankingdata.name[10] + "\n" + "\n";

        ScoreText.text = (int)rankingdata.time[0] / 60 + " : " + (int)rankingdata.time[0] % 60 + "\n" + "\n" +
                         (int)rankingdata.time[1] / 60 + " : " + (int)rankingdata.time[1] % 60 + "\n" + "\n" +
                         (int)rankingdata.time[2] / 60 + " : " + (int)rankingdata.time[2] % 60 + "\n" + "\n" +
                         (int)rankingdata.time[3] / 60 + " : " + (int)rankingdata.time[3] % 60 + "\n" + "\n" +
                         (int)rankingdata.time[4] / 60 + " : " + (int)rankingdata.time[4] % 60 + "\n" + "\n" +
                         (int)rankingdata.time[5] / 60 + " : " + (int)rankingdata.time[5] % 60 + "\n" + "\n" +
                         (int)rankingdata.time[6] / 60 + " : " + (int)rankingdata.time[6] % 60 + "\n" + "\n" +
                         (int)rankingdata.time[7] / 60 + " : " + (int)rankingdata.time[7] % 60 + "\n" + "\n" +
                         (int)rankingdata.time[8] / 60 + " : " + (int)rankingdata.time[8] % 60 + "\n" + "\n" +
                         (int)rankingdata.time[9] / 60 + " : " + (int)rankingdata.time[9] % 60 + "\n" + "\n" +
                         (int)rankingdata.time[10] / 60 + " : " + (int)rankingdata.time[10] % 60 + "\n" + "\n";
    }

    public void InputName(string name)
    {
        rankingdata.name[10] = name;
    }

    public void InputTime(float time)
    {
        rankingdata.time[10] = time;
        for (int i = 0; i < 10; i++)
        {
            if (time > rankingdata.time[i])
            {
                UIManager.instance.GetName();
                SaveData();
                return;
            }
        }
        SaveData();
        return;
    }
}
