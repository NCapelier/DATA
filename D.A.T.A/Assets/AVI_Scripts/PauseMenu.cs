using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.Joystick1Button7)))
        {
            if (GameisPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        SceneManager.UnloadScene("AVI_Pause Menu");
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void Pause()
    {
        SceneManager.LoadScene("AVI_Pause Menu", LoadSceneMode.Additive);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
