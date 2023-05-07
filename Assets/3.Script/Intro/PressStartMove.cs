using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStartMove : MonoBehaviour
{
    bool upFlg;
    private RectTransform rectTransform;
    private void Awake()
    {
        TryGetComponent(out rectTransform);
        upFlg = true;
        StartCoroutine("movePressStart_co", 0.05f);
    }
    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator movePressStart_co()
    {
        WaitForSeconds waitSec = new WaitForSeconds(0.2f);
        while (true)
        {
            if (upFlg == true)
            {
                rectTransform.anchoredPosition += new Vector2(0, 4f);
            }
            else
            {
                rectTransform.anchoredPosition -= new Vector2(0, 4f);
            }

            if (rectTransform.anchoredPosition.y > 160f)
            {
                upFlg = false;
            }
            else if (rectTransform.anchoredPosition.y < 80f)
            {
                upFlg = true;
            }
            yield return waitSec;
        }
    }
}
