using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    [SerializeField] private Text TouchText;
    [SerializeField] private Image rankingImage;
    [SerializeField] private InputField NameInput;

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
        }
    }

    public void GetName()
    {
        DataManager.instance.InputName(NameInput.GetComponent<InputField>().text);
    }
}
