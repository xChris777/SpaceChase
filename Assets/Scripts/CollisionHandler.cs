using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delayTimeFail = 1;
    [SerializeField] ParticleSystem explosionParticles;

    bool isTransitioning = false;

    /*
      private void OnCollisionEnter(Collision other)

    {

        {
            Debug.Log(this.name + "- - collided with - -" + other.gameObject.name);
        }       //method of displaying this information, using + signs (called concatenate aka join) info
       



}
    */
    private void OnTriggerEnter(Collider other)

    {        /*
    {
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}");
            //displays another way of displaying this information, using string interpolation
    }
        */

        if (isTransitioning)
        { return; }

        else
        {
            StartCrashSequence();
        }

    }
    void StartCrashSequence()
    {
        isTransitioning = true;
        explosionParticles.Play();
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Rigidbody>().useGravity = true;
        Invoke("ReloadLevel", delayTimeFail);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
