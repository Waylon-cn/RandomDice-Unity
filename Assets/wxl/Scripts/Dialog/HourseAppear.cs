using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourseAppear : MonoBehaviour
{
    private bool IsFirstHourse = true;
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
        if (IsFirstHourse)
            GameEventSystem.instance.IsHourse = true;
        IsFirstHourse = false;
    }
}
