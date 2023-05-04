using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] pipePool;
    [SerializeField] private GameObject[] pipePrefab;

    private int poolCount = 12;

    private bool canSpawn = false;

    private void Awake()
    {
        pipePool = new GameObject[poolCount];

        for (int i = 0; i < poolCount; i++)
        {
            if (i >= 6)
            {
                pipePool[i] = Instantiate(pipePrefab[i % 6], transform.position, Quaternion.identity);
            }
            else
            {
                pipePool[i] = Instantiate(pipePrefab[i], transform.position, Quaternion.identity);
            }

            pipePool[i].SetActive(false);
        }
    }

    
    private void Start()
    {
        StartCoroutine(SpawnPipe_co1());         
    }

    IEnumerator SpawnPipe_co1()
    {
        WaitForSeconds spawnDelay = new WaitForSeconds(3f);
        while (true)
        {
            GameObject pipe = pipePool[Random.Range(0, 12)];

            if (!pipe.activeSelf)
            {
                pipe.SetActive(true);
            }
            else
            {
                continue;
            }
            yield return spawnDelay;
        }
    }
}
