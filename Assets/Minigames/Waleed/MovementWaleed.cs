using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWaleed : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public float speed;
    public float dashSpeed;
    public float dashCooldown;
    private int direction;
    private Vector2 lastDirection;
    private Vector2 movement;
    private Vector2 mousePos;
    public Vector2 dashDir;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
        movement.x = Input.GetAxisRaw("Horizontal"); ;
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lastDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lastDirection.y, lastDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        dashDir = mousePos - rb.position;
        Dash();
    }

    void Dash() {
        if (Input.GetKey("space"))
        {
            rb.MovePosition(rb.position + dashDir * dashSpeed * Time.fixedDeltaTime);
        }
    }
}
