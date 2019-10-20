using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsAudioScript2 : MonoBehaviour
{
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !PauseMenu.GameIsPaused && !GameControl.Instance.isGameOver)
        {
            MusicSource.Play();
        }
    }
}
