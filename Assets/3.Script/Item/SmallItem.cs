using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallItem : MonoBehaviour
{
    private float itemTime = 10f;
    private bool isUse;
    private float moveSpeed = 15f;
    private float endPos_X = -50f;
    private void OnEnable()
    {
        moveSpeed = 15f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")&&!isUse)
        {
            isUse = true;
            StartCoroutine(SmallItem_co(collision));
            transform.position = new Vector3(collision.transform.position.x-40, 0, collision.transform.position.z);
            moveSpeed = 0f;
        }
    }

    private IEnumerator SmallItem_co(Collision collision)
    {
        collision.transform.localScale *= 0.5f;

        yield return new WaitForSeconds(itemTime);

        collision.transform.localScale *= 2f;
        isUse = false;
        transform.gameObject.SetActive(false);
    }
    private void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (transform.position.x <= endPos_X)
        {
            gameObject.SetActive(false);
        }

    }
}
