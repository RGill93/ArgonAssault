using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    /*
     * When the first level loads the music will
     * continue to play
     */
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        Invoke("LoadFirstScene", 2f);
	}
	
	// Update is called once per frame
	void LoadFirstScene()
    {
        SceneManager.LoadScene(1);       
	}
}
