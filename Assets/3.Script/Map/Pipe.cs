using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float createPos_X = 150f;
    private float endPos_X = -40f;

    [SerializeField] private Movement movement;


    private void Update()
    {
        if(transform.position.x <= endPos_X)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        movement.isPlay = true;
        transform.position = new Vector3(createPos_X, 0, 0);
    }

    
}
