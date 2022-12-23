using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPastorRoom : MonoBehaviour
{
    private bool IsFirst = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (IsFirst)
            GameEventSystem.instance.IsFirstPastorRoom = true;
        IsFirst = false;
    }
}
