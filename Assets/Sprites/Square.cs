using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed;
    Rigidbody2D rb2d;
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xVelocity = Input.GetAxisRaw("Horizontal");
        float yVelocity = Input.GetAxisRaw("Vertical");
        //Debug.LogError("x velocity: " + xVelocity);
        rb2d.velocity = new Vector2(movementSpeed * xVelocity, movementSpeed * yVelocity);
        /*float xVelocity = 0.0f;
        if (Input.GetKey(KeyCode.A))
        {
            //Left
            xVelocity = -1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Right
            xVelocity = 1.0f;
        }
        rb2d.velocity = new Vector2(xVelocity, rb2d.velocity.y);*/
    }
}
