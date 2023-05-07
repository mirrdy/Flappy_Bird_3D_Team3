using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float moveSpeed = 15f;

    //public bool isPlay;

    private void OnEnable()
    {
        //isPlay = false;
    }

    private void Update()
    {
        //if (isPlay)
        //{
        //    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        //}
        if(GameManager.Instance.GetIsPlaying() && !GameManager.Instance.isGameOver)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
}
