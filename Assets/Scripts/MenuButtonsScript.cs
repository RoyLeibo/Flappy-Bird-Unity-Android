using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsScript : MonoBehaviour
{

    public void OnSinglePlayer()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMultiPlayer()
    {
        SceneManager.LoadScene(2);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
