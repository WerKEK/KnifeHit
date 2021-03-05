using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
  //  public Transform Wood;
    public Transform SpawnPos;
    public GameObject Apple;
    SpawnAppleChance Chance;
    
    void Start()
    {
        float Range = UnityEngine.Random.Range(0f, 101f);
        if (/*Chance.SpawnChance*/25f > Range)
        {
            Instantiate(Apple, SpawnPos);
           // Apple.transform.SetParent(Wood);
        }
    }
}
