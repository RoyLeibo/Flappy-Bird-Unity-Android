using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayAudioScript : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioClip MusicClip;
    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClip;
        MusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
