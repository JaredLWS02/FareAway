using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coralSpawner2 : MonoBehaviour
{   
    public GameObject red;
    private float startPos;
    private float temp;
    private float startPosY;
    private float startPosZ;
    private float length;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        temp = transform.position.x;
        startPosY = transform.position.y;
        startPosZ = transform.position.z;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            spawnCorals();
            startPos = startPos + temp;
        }
    }

    void spawnCorals()
    {
        Debug.Log("Spawned");
         GameObject newObject = Instantiate(red, new Vector3(startPos + length + 10, startPosY-3, 10), Quaternion.identity);
    }  
}
