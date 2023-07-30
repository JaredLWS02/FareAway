using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasticSpawner : MonoBehaviour
{
    public GameObject white;
    public GameObject blue;
    public GameObject fPlastic;
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
            Debug.Log("plastics");
            Instantiate(fPlastic, new Vector3(startPos + length + 15, startPosY +3, startPosZ), Quaternion.identity);
            Instantiate(white, new Vector3(startPos + length + 5, startPosY -1 , startPosZ), Quaternion.identity);
            Instantiate(blue, new Vector3(startPos + length + 8, startPosY +4, startPosZ), Quaternion.identity);
            startPos = startPos + temp;
        }
    }
}
