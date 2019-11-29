using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    GameObject menuPause;
    GameObject menuOption;
    GameObject menuControles;
    GameObject menuSon;


    private void Awake()
    {
        menuPause = transform.GetChild(0).gameObject;
        menuOption = transform.GetChild(1).gameObject;
        menuSon = transform.GetChild(2).gameObject;
        menuControles = transform.GetChild(3).gameObject;
    }

    private void Update()
    {
        // perte controle du déplacement du joueur
    }

    public void Options()
    {
        menuOption.SetActive(true);
        menuPause.SetActive(false);
    }

    public void Back()
    {
        menuOption.SetActive(false);
        menuPause.SetActive(true);
    }
    public void BackSound()
    {
        menuSon.SetActive(false);
        menuOption.SetActive(true);
    }

    public void sound()
    {
        menuSon.SetActive(true);
        menuOption.SetActive(false);
    }

    public void Controls()
    {
        menuControles.SetActive(true);
        menuPause.SetActive(false);
    }

    public void Resume()
    {
        SceneManager.UnloadScene("Pause_Menu");
        Time.timeScale = 1f;
    }

    public void Sound_Control()
    {
        //replace with slider
    }

    public void Music_Control()
    {
        //replace with slider
    }

    public void Abort()
    {
        Application.Quit();
    }
}
