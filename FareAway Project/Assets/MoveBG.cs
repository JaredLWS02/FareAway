using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    private float startPos;
    [SerializeField] private GameObject Cam;
    [SerializeField] private float parallax;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (Cam.transform.position.x * parallax);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
