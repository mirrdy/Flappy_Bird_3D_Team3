using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] pipePool;
    [SerializeField] private GameObject[] pipePrefab;
    [SerializeField] private GameObject itemSpawner;

    // Touch 해서 게임 시작되면 True로 
    //private bool isSpawnPipe;

    private int poolCount = 12;
    private int itemSpawnCount = 0;
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
            pipePool[i].transform.SetParent(this.transform);
        }
    }

    
    private void Start()
    {
        StartCoroutine(SpawnPipe_co1());         
    }

    IEnumerator SpawnPipe_co1()
    {
        WaitForSeconds spawnDelay = new WaitForSeconds(2f);
        while (true)
        {
            if (GameManager.Instance.GetIsPlaying() && !GameManager.Instance.isGameOver)
            {
                int randNum = Random.Range(0, 12);
                GameObject pipe = pipePool[randNum];
                if (!pipe.activeSelf)
                {
                    pipe.SetActive(true);
                    itemSpawnCount++;
                    if (itemSpawnCount >= 10)
                    {
                        itemSpawner.TryGetComponent(out ItemSpawner itemSpawn);
                        itemSpawn.ItemSpawn(randNum);
                        itemSpawnCount = 0;
                    }
                }
                else
                {
                    continue;
                }
            }
            yield return spawnDelay;
        }
    }
}
