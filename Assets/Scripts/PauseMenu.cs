using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    void Start(){
        GameIsPaused = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !GameControl.Instance.isGameOver)
        {
            Pause();
        }    
    }

    private void Pause()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    private void Resume()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void OnResume()
    {
        Resume();
    }

    public void OnMainMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }
}
