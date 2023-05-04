using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float moveSpeed = 15f;
    private float createPos_X = 70f;
    private float endPos_X = -40f;

    private void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if(transform.position.x <= endPos_X)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        transform.position = new Vector3(createPos_X, 0, 0);
    }

    
}
