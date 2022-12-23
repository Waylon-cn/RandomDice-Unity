using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcWalk : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float speed = 3;
    private Rigidbody2D rigidbody2d;


    private int direction = 1;
    public float changeTime = 3;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer =GetComponent<SpriteRenderer>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            spriteRenderer.flipX=!spriteRenderer.flipX;
            //animator.SetFloat("MoveX", direction);
            timer = changeTime;
        }
        Vector2 position = rigidbody2d.position;

        position.x = position.x - Time.deltaTime * speed * direction;
        rigidbody2d.MovePosition(position);
    }
}
