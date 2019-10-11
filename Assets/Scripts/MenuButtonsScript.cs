using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsScript : MonoBehaviour
{

    public GamePlayAudioScript musicSource;

    public void Start()
    {
        musicSource.PlayMusic();
    }

    public void OnSinglePlayer()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMultiPlayer()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
