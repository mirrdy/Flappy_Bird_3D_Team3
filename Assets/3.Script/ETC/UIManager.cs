using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    [SerializeField] private Text TouchText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Update()
    {
        FontCainge();
    }

    private void FontCainge()  // Coroutine 사용 하는 Method
    {
        StartCoroutine(nameof(FontColor_co));
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
}
