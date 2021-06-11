using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayerController : MonoBehaviour
{
    public float movementSpeed;
    public string movementAxis;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float yVelocity = Input.GetAxisRaw(movementAxis);
        rb2d.velocity = new Vector2(rb2d.velocity.x, movementSpeed * yVelocity);
    }
}
