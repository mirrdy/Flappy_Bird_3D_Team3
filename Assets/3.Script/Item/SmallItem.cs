using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallItem : MonoBehaviour
{
    private float itemTime = 10f;
    private bool isUse;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")&&!isUse)
        {
            isUse = true;
            StartCoroutine(SmallItem_co(collision));
            transform.position = new Vector3(collision.transform.position.x, 0, collision.transform.position.z - 20f);
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
}
