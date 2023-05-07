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
    private bool isPlaying;
    public bool isGameOver;
    public delegate void OnStartGame();
    public event OnStartGame onStartGame;
    public float startTime;
    public float playTime;

    void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        playTime = Time.time - startTime;
        if(isGameOver)
        {
            return;
        }
    }


    public bool GetIsPlaying()
    {
        return isPlaying;
    }
    public void SetIsPlaying(bool isPlaying)
    {
        this.isPlaying = isPlaying;
        if (isPlaying)
        {
            onStartGame.Invoke();
        }
    }
}
