using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.name + "- - collided with - -" + other.gameObject.name);
    }       //method of displaying this information, using + signs (called concatenate aka join) info

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}");
            //displays another way of displaying this information, using string interpolation
    }
}
