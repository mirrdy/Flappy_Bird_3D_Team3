using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Touch touch;
    private Rigidbody myRigid;
    private float speed = 7f;
    private float itemTime = 5f;


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
        if (GameManager.Instance.isGameOver || !isFlying)
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
        if(collision.collider.CompareTag("Item"))
        {
            if(collision.gameObject.TryGetComponent(out Ghost ghost))
            {
                StartCoroutine(GhostItem_co());
                //transform.position = new Vector3(collision.transform.position.x - 40, 0, collision.transform.position.z);
            }
            else if(collision.gameObject.TryGetComponent(out SmallItem smallItem))
            {
                StartCoroutine(SmallItem_co());
                //transform.position = new Vector3(collision.transform.position.x - 40, 0, collision.transform.position.z);
            }
            collision.gameObject.SetActive(false);
        }
    }

    private IEnumerator GhostItem_co()
    {
        TryGetComponent(out BoxCollider collider);
        collider.enabled = false;
        transform.GetChild(0).TryGetComponent(out SkinnedMeshRenderer renderer);
        renderer.material.shader = Shader.Find("GUI/Text Shader");
        renderer.material.color = new Color32(148, 236, 69, 55);
        yield return new WaitForSeconds(itemTime);

        collider.enabled = true;
        renderer.material.shader = Shader.Find("Unlit/Texture");
    }

    private IEnumerator SmallItem_co()
    {
        transform.localScale *= 0.5f;

        yield return new WaitForSeconds(itemTime);

        transform.localScale *= 2f;
    }
    private void Collide()
    {
        Debug.Log("Ãæµ¹");
        GameManager.Instance.isGameOver = true;
        myRigid.useGravity = true;
        myRigid.velocity = Vector3.zero;
    }





}
