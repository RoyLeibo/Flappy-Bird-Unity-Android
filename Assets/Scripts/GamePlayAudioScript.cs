using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayAudioScript : MonoBehaviour
{
    public static GamePlayAudioScript gamePlayAudioScript { get; private set; }

    public AudioSource MusicSource;
    public AudioClip MusicClip;
    
    void Start()
    {
        MusicSource.clip = MusicClip;
    }
    
    private void Awake()
    {
        if (gamePlayAudioScript == null)
        {
            gamePlayAudioScript = this;
        }
        DontDestroyOnLoad(transform.gameObject);
        MusicSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (MusicSource.isPlaying) return;
        MusicSource.Play();
    }

    public void StopMusic()
    {
        MusicSource.Stop();
    }
}
