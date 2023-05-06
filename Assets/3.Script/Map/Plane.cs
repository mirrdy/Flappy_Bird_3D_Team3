using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private float width = 100f;

    private void Update()
    {
        if (transform.position.x < -width * 3)
        {
            transform.position = Vector3.right * width * 3;
        }
    }
}
