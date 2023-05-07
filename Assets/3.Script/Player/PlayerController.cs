using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Touch touch;
    private Rigidbody myRigid;
    private float mag = 15f;
    private Vector3 force;
    private bool isFlying;


    private void Awake()
    {
        TryGetComponent(out myRigid);
        myRigid.useGravity = false;
        GameManager.Instance.onStartGame += (() => isFlying = true);
        force = Vector3.up * mag;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        if(transform.position.y < 0)
        {
            Collide();
        }
        InputTouch();
    }

    private void InputTouch()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            TouchPhase touchPhase = touch.phase;

            switch (touchPhase)
            {
                case TouchPhase.Began:
                    {
                        myRigid.AddForce(force);
                        break;
                    }
                case TouchPhase.Moved:
                    {
                        myRigid.AddForce(force);
                        break;
                    }
                case TouchPhase.Stationary:
                    {
                        myRigid.AddForce(force);
                        break;
                    }
                case TouchPhase.Ended:
                    {
                        break;
                    }
                case TouchPhase.Canceled:
                    {
                        break;
                    }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pipe"))
        {
            Collide();
        }
    }
    private void Collide()
    {
        Debug.Log("Ãæµ¹");
        GameManager.Instance.isGameOver = true;
        myRigid.velocity = Vector3.zero;
    }
}
