using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public static bool GameEnd = false;
    public GameObject losingScreenUI;


    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("enemy"))
        {
            Stop();
        }
    }
    public void Stop()
    {
        losingScreenUI.SetActive(true);
        Time.timeScale = 0f;
        GameEnd = true;
    }

}

