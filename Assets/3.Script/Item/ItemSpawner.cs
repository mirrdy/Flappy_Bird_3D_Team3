using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject ghostItem;
    [SerializeField] GameObject smallItem;

    private GameObject[] itemList = new GameObject[2];

    private void Awake()
    {
        itemList[0] = Instantiate(ghostItem, transform.position, Quaternion.identity);
        itemList[0].SetActive(false);
        itemList[1] = Instantiate(smallItem, transform.position, Quaternion.identity);
        itemList[1].SetActive(false);
    }

    public void ItemSpawn(int randnum)
    {
        int randItem = Random.Range(0, 2);
        switch (randnum)
        {
            case 0: itemList[randItem].transform.position = new Vector3(150, 14.5f, 0); itemList[randItem].SetActive(true); break;
            case 1: itemList[randItem].transform.position = new Vector3(150, 14.5f, 0); itemList[randItem].SetActive(true); break;
            case 2: itemList[randItem].transform.position = new Vector3(150, 14.5f, 0); itemList[randItem].SetActive(true); break;
            case 3: itemList[randItem].transform.position = new Vector3(150, 10f, 0); itemList[randItem].SetActive(true); break;
            case 4: itemList[randItem].transform.position = new Vector3(150, 23f, 0); itemList[randItem].SetActive(true); break;
            case 5: itemList[randItem].transform.position = new Vector3(150, 22f, 0); itemList[randItem].SetActive(true); break;
            case 6: itemList[randItem].transform.position = new Vector3(150, 14.5f, 0); itemList[randItem].SetActive(true); break;
            case 7: itemList[randItem].transform.position = new Vector3(150, 14.5f, 0); itemList[randItem].SetActive(true); break;
            case 8: itemList[randItem].transform.position = new Vector3(150, 14.5f, 0); itemList[randItem].SetActive(true); break;
            case 9: itemList[randItem].transform.position = new Vector3(150, 10f, 0); itemList[randItem].SetActive(true); break;
            case 10: itemList[randItem].transform.position = new Vector3(150, 23f, 0); itemList[randItem].SetActive(true); break;
            case 11: itemList[randItem].transform.position = new Vector3(150, 22f, 0); itemList[randItem].SetActive(true); break;

        }
    }


}
