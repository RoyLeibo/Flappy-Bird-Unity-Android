using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static bool isSingle;

    public static GameControl Instance;
    public float scrollSpeed = -1.5f;
    public bool isGameOver = false;
    private int score = 0;
    public Text scoreText;
    public GameObject gameOverText;
    public GameObject clickForRestartText;
    private bool fadeOut = true;
    private TimeSpan timeSpan = TimeSpan.FromSeconds(0.25);
    private DateTime startTime;
    public AudioSource audioSource;
    public AudioSource coinAudioSource;
    public AudioSource miniAudioSource;
    // Start is called before the first frame update
    public void Start()
    {
        GameControl.isSingle = true;
    }
    void Awake() {
        if(Instance == null){
            Instance = this;
        }else if(Instance!=this){
            Destroy(gameObject);
        }
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is over
        if(isGameOver){
            //every 0.25 seconds
            if(DateTime.UtcNow - startTime >= timeSpan){
                startTime = DateTime.UtcNow;
                Color restartColor = clickForRestartText.
                GetComponent<Text>().color;
                //if the alpha of the text is 0.5;
                if(restartColor.a == 0.5f){
                    //if the text should fade out.
                    if(fadeOut){
                        //change the color and fadeout.
                        restartColor.r = UnityEngine.Random.Range(0.0f,1.0f);
                        restartColor.b = UnityEngine.Random.Range(0.0f,1.0f);
                        restartColor.g = UnityEngine.Random.Range(0.0f,1.0f);
                        restartColor.a = 0.0f;
                        //the text now should fade in.
                        fadeOut = false;
                    }else{
                        //the text alpha should be 1.0f (faded in)
                        restartColor.a = 1.0f;
                        //the text should now fade out.
                        fadeOut = true;
                    }
                    //if the alpha isn't 0.5f make it 0.5f;
                }else{
                    restartColor.a = 0.5f;
                }
                //change the text color object to restartColor.
                clickForRestartText.GetComponent<Text>().
                color = restartColor;
            }
            
        }
        //restart the game when the mouse is pressed.
        if(isGameOver && Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void Score(){
        if(isGameOver) return;
        score++;
        scoreText.text = "Score: " + score;
    }
    public void Die(){
        isGameOver = true;
        gameOverText.SetActive(true);
        clickForRestartText.SetActive(true);
        startTime = DateTime.UtcNow;
    }

    public void MonsterDead()
    {
        audioSource.Play();
    }
}
