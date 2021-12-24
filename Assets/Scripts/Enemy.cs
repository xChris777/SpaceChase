using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    [SerializeField] AudioClip explosion;
    [SerializeField] float destroyDelay = 2f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;

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
        if (isTransitioning)
        { return; }

        else
        {
            isTransitioning = true;
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parent;
            audioSource.Stop();
            GetComponent<MeshRenderer>().enabled = false;
            audioSource.PlayOneShot(explosion);
            Destroy(gameObject);

        }
    }
}
