using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    [SerializeField] private Text TouchText;
    [SerializeField] private Image rankingImage;
    [SerializeField] public  InputField NameInput;
    [SerializeField] private Text Timer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(nameof(FontColor_co));
    }

    private void LateUpdate()
    {
        CloseRanking();
        Timer_output();
    }

    IEnumerator FontColor_co()  // Touch The Screen 색상 변경 Coroutine
    {
        while (true)
        {
            if(TouchText.color.Equals(Color.white)) yield return new WaitForSeconds(1f);
            TouchText.color = Color.black;
            if (TouchText.color.Equals(Color.black)) yield return new WaitForSeconds(1f);
            TouchText.color = Color.white;
        }
    }

    public void CloseRanking()
    {
        if (rankingImage.gameObject.activeSelf && Input.anyKeyDown)
        {
            rankingImage.gameObject.SetActive(false);
        }
        else if (!rankingImage.gameObject.activeSelf && Input.anyKeyDown)
        {
            Invoke(nameof(GameStart), 0.2f);
        }
    }

    public void GameStart()
    {
        if (!rankingImage.gameObject.activeSelf)
        {
            TouchText.gameObject.SetActive(false);
            GameManager.Instance.SetIsPlaying(true);
        }
    }

    public void GetName()
    {
        if (GameManager.Instance.isGameOver)
        {
            NameInput.gameObject.SetActive(true);
        }
    }

    public void Timer_output()
    {
        float time = GameManager.Instance.playTime;

        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);
        Timer.text = string.Format("{0:D2} : {1:D2}", min, sec);
    }

    public void SetName(string text)
    {
        NameInput.text = text;
        DataManager.instance.InputName(NameInput.text);
        DataManager.instance.SaveData();

        Invoke(nameof(SetName_rate), 0.2f);
    }

    public void SetName_rate()
    {
        rankingImage.gameObject.SetActive(true);
        DataManager.instance.Print();
    }
}
