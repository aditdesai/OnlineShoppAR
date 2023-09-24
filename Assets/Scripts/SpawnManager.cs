using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] marketplaceItems;
    public Vector3 spawnPoint;

    void Awake()
    {
        int itemNum = PlayerPrefs.GetInt("itemNumber");
        Debug.Log(itemNum);
        Instantiate(marketplaceItems[itemNum - 1], spawnPoint, Quaternion.identity);
    }


    void Update()
    {
        
    }
}
