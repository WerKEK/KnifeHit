using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    public Transform Wood;
    public Transform SpawnPos1;
    public Transform SpawnPos2;
    public Transform SpawnPos3;
    public GameObject Knife1;
    public GameObject Knife2;
    public GameObject Knife3;
    void Start()
    {
        float Range = UnityEngine.Random.Range(0f, 101f);
        if (100f > Range)
        {
            Instantiate(Knife1, SpawnPos1);
        }
        
       if (50f > Range)
       {
           Instantiate(Knife2, SpawnPos2);
       }

        if (10f > Range)
        {
            Instantiate(Knife3, SpawnPos3);
        }
    }
    

}
