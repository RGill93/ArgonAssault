﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start()
    {
		
	}
    // Update is called once per frame
    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}