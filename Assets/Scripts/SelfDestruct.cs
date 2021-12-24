using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]float destroyDelay = 3;
    
    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

}
