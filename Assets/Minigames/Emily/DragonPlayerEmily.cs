using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPlayerEmily : MonoBehaviour
{
    public float movementSpeed;
    // public string movementAxisx;
    // public string movementAxisy;


    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xVelocity = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(rb2d.velocity.x, movementSpeed * xVelocity);
        float yVelocity = Input.GetAxisRaw("Vertical");
        rb2d.velocity = new Vector3(rb2d.velocity.y, movementSpeed * yVelocity);

    }
}
