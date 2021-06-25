using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAden : MonoBehaviour
{
    public float xSpeed;
    public float jumpSpeed;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xVelocity = xSpeed * Input.GetAxisRaw("Horizontal");
        float yVelocity = rb2d.velocity.y;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            yVelocity = jumpSpeed;
        }

        rb2d.velocity = new Vector2(xVelocity, yVelocity);
    }
}
