using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharkSpawner : MonoBehaviour
{
    public GameObject Shark;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            createShark();
        }
    }

    void createShark()
    {
        Instantiate(Shark, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
