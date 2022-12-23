using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundPastor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        other.gameObject.GetComponent<PlayerController>().isAroundPastor = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<PlayerController>().isAroundPastor = false;
    }
}
