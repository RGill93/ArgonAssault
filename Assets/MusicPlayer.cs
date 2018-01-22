using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    /*
     * When the first level loads the music will
     * continue to play
     */
    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        if(numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }        
    }    
}
