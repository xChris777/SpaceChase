using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    [SerializeField] AudioClip explosion;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] float destroyDelay = 2f;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int hitPoints = 4;
    

    AudioSource audioSource;

    bool isTransitioning = false;

    Scoreboard scoreBoard;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreBoard = FindObjectOfType<Scoreboard>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (hitPoints > 0)

        {
            GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity); 
            vfx.transform.parent = parent;
            Debug.Log("Hit");
            SubtractHP();
            ProcessHit();
        }

        else if (hitPoints == 0)
        {
            KillEnemy();
            ProcessHit();
        }
    }

    private void SubtractHP()
    {
        hitPoints = hitPoints - 1;
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        audioSource.Stop();
        GetComponent<MeshRenderer>().enabled = false;
        audioSource.PlayOneShot(explosion);
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        scoreBoard.ModifyScore(scorePerHit);
    }
}
