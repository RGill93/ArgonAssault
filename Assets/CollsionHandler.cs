using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollsionHandler : MonoBehaviour
{

    [Tooltip("In seconds")][SerializeField] float levelDelay = 1f;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("reloadScene", levelDelay);
    }

    private void StartDeathSequence()
    {     
        SendMessage("OnPlayerDeath");
    }

    // String referenced
    private void reloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
