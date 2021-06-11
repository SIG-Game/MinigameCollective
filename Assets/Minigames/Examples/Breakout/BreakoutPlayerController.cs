using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutPlayerController : MonoBehaviour
{
    public float movementSpeed;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(horizontal * movementSpeed, 0.0f);
    }
}
