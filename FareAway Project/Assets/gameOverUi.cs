using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverUi : MonoBehaviour
{

    public GameObject gameOverUI;
    public int Respawn = 1;

    void Start()
    {
        gameOverUI.SetActive(false);
    }
    void Update()
    {

    }

    public void retry()
    {
        SceneManager.LoadScene(Respawn);
        Time.timeScale = 1f;
    }
    public void goToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
