using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OfficePlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public int speed = 5;
    public bool canMove = true;
    
    private Vector2 lookDirection = new Vector2(1, 0);
    private Animator animator;
    
    private float h, v;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }
    
    private void FixedUpdate()
    {
        if (canMove)
        {
            Vector2 move = new Vector2(h, v);
            if (!Mathf.Approximately(move.x, 0) || !Mathf.Approximately(move.y, 0))
            {
                lookDirection.Set(move.x, move.y); //lookDirection=move;
                lookDirection.Normalize();
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude); //move��ģ��

            Vector2 position = transform.position;
            position = position + speed * move * Time.deltaTime;
            rigidbody2d.MovePosition(position);
        }
        else
        {
            rigidbody2d.velocity = Vector2.zero;
        }
    }
}
