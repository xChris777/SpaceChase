using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WelcomeMessage : MonoBehaviour
{

    [SerializeField] float destroyDelay; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RemoveMessage();
    }

    private void RemoveMessage()
    {
        Destroy(gameObject, destroyDelay);
    }
}
