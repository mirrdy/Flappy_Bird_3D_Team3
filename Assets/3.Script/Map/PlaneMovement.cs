using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    private float moveSpeed = 15f;
    private float width = 50f;

    private void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -width * 2)
        {
            transform.position = Vector3.right * width * 2;
        }
    }
}
