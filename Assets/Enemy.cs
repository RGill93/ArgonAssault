﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;

    [SerializeField] int hits = 3;
    

    ScoreBoard scoreBoard;   

    // Use this for initialization
    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        
    }

    private void AddBoxCollider()
    {
        Collider BoxCollider = gameObject.AddComponent<BoxCollider>();
        BoxCollider.isTrigger = false;
    }    

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();        
        
        if(hits <= 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits = hits - 1;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}