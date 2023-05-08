using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Image rankingImage;

    public void Onclic_Ranking()
    {
        rankingImage.gameObject.SetActive(true);
        DataManager.instance.Print();
    }

    public void ReStart()
    {
        GameManager.Instance.RestartGame();
        StartCoroutine(nameof(Restart_co));
    }

    IEnumerator Restart_co()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
