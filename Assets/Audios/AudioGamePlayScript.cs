using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGamePlayScript : MonoBehaviour
{
    public static AudioGamePlayScript gamePlayAudioScript = null;
    public static AudioGamePlayScript GamePlayAudioScript
    {
        get { return gamePlayAudioScript; }
    }

    void Awake()
    {
        if (gamePlayAudioScript != null && gamePlayAudioScript != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            gamePlayAudioScript = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
