using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Touch touch;
    private Rigidbody myRigid;
    private float speed = 7f;
    
    private bool isFlying;


    private void Awake()
    {
        TryGetComponent(out myRigid);
        myRigid.useGravity = false;
        GameManager.Instance.onStartGame += (() => isFlying = true);
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
        Vector3 dirVector = speed * Time.deltaTime * Vector3.up;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            TouchPhase touchPhase = touch.phase;
            
            switch (touchPhase)
            {
                case TouchPhase.Began: case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    {
                        myRigid.MovePosition(transform.position + dirVector);
                        break;
                    }
                //case TouchPhase.Ended:
                //    {
                //        break;
                //    }
                //case TouchPhase.Canceled:
                //    {
                //        break;
                //    }
                default:
                    {
                        //myRigid.MovePosition(transform.position - dirVector);
                        break;
                    }
            }
        }
        else
        {
            myRigid.MovePosition(transform.position - dirVector);
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
        myRigid.useGravity = true;
        myRigid.velocity = Vector3.zero;
    }
}
