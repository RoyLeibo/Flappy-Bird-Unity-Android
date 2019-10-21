using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiGameControl : MonoBehaviour
{
    public static MultiGameControl Instance;
    public float scrollSpeed = -1.5f;
    public bool isGameOver = false;
    private int score1 = 0;
    public Text scoreText1;
    private int score2 = 0;
    public Text scoreText2;
    public GameObject gameOverText;
    public GameObject clickForRestartText;
    private bool fadeOut = true;
    private TimeSpan timeSpan = TimeSpan.FromSeconds(0.25);
    private DateTime startTime;
    public AudioSource audioSource;
    public AudioSource coinAudioSource;
    public AudioSource miniAudioSource;
    public int winner;
    // Start is called before the first frame update
    public void Start()
    {
        GameControl.isSingle = false;
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1;
        GameControl.isSingle = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is over
        if (isGameOver)
        {
            //every 0.25 seconds
            if (DateTime.UtcNow - startTime >= timeSpan)
            {
                startTime = DateTime.UtcNow;
                Color restartColor = clickForRestartText.
                GetComponent<Text>().color;
                //if the alpha of the text is 0.5;
                if (restartColor.a == 0.5f)
                {
                    //if the text should fade out.
                    if (fadeOut)
                    {
                        //change the color and fadeout.
                        restartColor.r = UnityEngine.Random.Range(0.0f, 1.0f);
                        restartColor.b = UnityEngine.Random.Range(0.0f, 1.0f);
                        restartColor.g = UnityEngine.Random.Range(0.0f, 1.0f);
                        restartColor.a = 0.0f;
                        //the text now should fade in.
                        fadeOut = false;
                    }
                    else
                    {
                        //the text alpha should be 1.0f (faded in)
                        restartColor.a = 1.0f;
                        //the text should now fade out.
                        fadeOut = true;
                    }
                    //if the alpha isn't 0.5f make it 0.5f;
                }
                else
                {
                    restartColor.a = 0.5f;
                }
                //change the text color object to restartColor.
                clickForRestartText.GetComponent<Text>().
                color = restartColor;
            }

        }
        //restart the game when the mouse is pressed.
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void Score1()
    {
        if (isGameOver) return;
        score1++;
        scoreText1.text = "Score: " + score1;
    }

    public void Score2()
    {
        if (isGameOver) return;
        score2++;
        scoreText2.text = "Score: " + score2;
    }

    public void Die(int winner)
    {
        if (!isGameOver)
        {
            GameControl.Instance.isGameOver = true;
            isGameOver = true;
            this.winner = winner;
            Text winnerText = gameOverText.GetComponent<Text>();
            winnerText.text = "Player " + this.winner + " Wins !!";
            gameOverText.SetActive(true);
            clickForRestartText.SetActive(true);
            startTime = DateTime.UtcNow;
        }
    }

    public void MonsterDead()
    {
        audioSource.Play();
    }
}
