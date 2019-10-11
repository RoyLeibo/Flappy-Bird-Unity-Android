using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayAudioScript : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioClip MusicClip;
    
    void Start()
    {
        MusicSource.clip = MusicClip;
    }
    
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        MusicSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        Debug.Log("Inside playMusic");
        if (MusicSource.isPlaying) return;
        MusicSource.Play();
    }

    public void StopMusic()
    {
        MusicSource.Stop();
    }
}
