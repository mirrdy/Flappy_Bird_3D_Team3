using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Touch touch;
    private Rigidbody myRigid;

    private void Awake()
    {
        TryGetComponent(out myRigid);
    }

    // Update is called once per frame
    void Update()
    {
        InputTouch();
    }

    private void InputTouch()
    {
        touch = Input.GetTouch(0);
        TouchPhase touchPhase = touch.phase;

        switch(touchPhase)
        {
            case TouchPhase.Began:
                {
                    myRigid.AddForce(Vector3.up);
                    break;
                }
            case TouchPhase.Moved:
                {
                    myRigid.AddForce(Vector3.up);
                    break;
                }
            case TouchPhase.Stationary:
                {
                    myRigid.AddForce(Vector3.up);
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
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ãæµ¹");
        GameManager.Instance.isGameOver = true;
        
    }
}
