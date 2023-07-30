using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatSpawner : MonoBehaviour
{
    public GameObject boat;
    private float temp;
    private float startPos;
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
            Debug.Log("hit1");
            Instantiate(boat, new Vector3(startPos + length + 50, startPosY - 5, startPosZ), Quaternion.identity);
            startPos = startPos + temp;
        }
    }
}
