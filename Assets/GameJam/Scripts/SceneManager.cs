using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    private void Awake()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TitleScreen"
            || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameOverScreen"
            || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "WinScreen")
            StartCoroutine(StartGame());
    }

    public void ChangeScene(int scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    IEnumerator StartGame()
    {
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        ChangeScene(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
