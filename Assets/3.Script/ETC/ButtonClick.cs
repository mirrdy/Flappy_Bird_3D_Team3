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

    public void ReSarte()
    {
        GameManager.Instance.RestartGame();
    }
}
