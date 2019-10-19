using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudioScript : MonoBehaviour
{
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public bool isPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClip;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameControl.isSingle)
        {
            if (GameControl.Instance.isGameOver && !isPlayed)
            {
                isPlayed = true;
                MusicSource.Play();
            }
        }
        else
        {
            if(MultiGameControl.Instance.isGameOver && !isPlayed)
            {
                isPlayed = true;
                MusicSource.Play();
            }
        }
    }
}
