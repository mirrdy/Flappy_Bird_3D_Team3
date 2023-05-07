using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallItem : MonoBehaviour
{
    private float itemTime = 10f;
    private float endPos_X = -50f;

    [SerializeField] private Movement movement;

    private void OnEnable()
    {
        //movement.isPlay = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(SmallItem_co(collision));
            transform.position = new Vector3(collision.transform.position.x-40, 0, collision.transform.position.z);
            //movement.isPlay = false;
        }
    }

    private IEnumerator SmallItem_co(Collision collision)
    {
        collision.transform.localScale *= 0.5f;

        yield return new WaitForSeconds(itemTime);

        collision.transform.localScale *= 2f;
        transform.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (transform.position.x <= endPos_X)
        {
            gameObject.SetActive(false);
        }

    }
}
