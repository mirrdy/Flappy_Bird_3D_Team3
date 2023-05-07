using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private float itemTime = 5f;
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
            StartCoroutine(GhostItem_co(collision));
            transform.position = new Vector3(collision.transform.position.x-40, 0, collision.transform.position.z);
            //movement.isPlay = false;
        }     
    }

    private IEnumerator GhostItem_co(Collision collision)
    {
        collision.collider.enabled = false;
        collision.transform.GetChild(0).TryGetComponent(out SkinnedMeshRenderer renderer);
        renderer.material.shader = Shader.Find("UI/Unlit/Transparent");
        renderer.material.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(itemTime);
        collision.collider.enabled = true;
        renderer.material.shader = Shader.Find("Unlit/Texture");
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (transform.position.x <= endPos_X)
        {
            gameObject.SetActive(false);
        }
    }
}
