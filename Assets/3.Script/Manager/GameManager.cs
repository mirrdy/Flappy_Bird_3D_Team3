using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameManager>();
                }
                return instance;

            }
        }
    }

    public int score = 0;
    private bool isPlaying = false;
    public bool isGameOver = false;
    public bool isSaved = false;
    
    public float startTime;
    public float playTime;

    public delegate void OnStartGame();
    public event OnStartGame onStartGame;

    void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if(isGameOver)
        {
            if(!isSaved)
            {
                //DataManager.instance.InputName
                DataManager.instance.InputTime(playTime);
                // 데이터매니저에서 해당 타임이 10위 안쪽인지 확인하고 이름 입력받는 UI 거쳐서 저장
                isSaved = true;
            }
            return;
        }
        if (isPlaying)
        {
            playTime = Time.time - startTime;
        }
    }


    public bool GetIsPlaying()
    {
        return isPlaying;
    }
    public void SetIsPlaying(bool isPlaying)
    {
        if(this.isPlaying == isPlaying)
        {
            return;
        }

        this.isPlaying = isPlaying;
        if (isPlaying)
        {
            onStartGame.Invoke();
            startTime = Time.time;
        }
    }
}
