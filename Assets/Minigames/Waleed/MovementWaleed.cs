using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWaleed : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public float speed = 5f;
    public float dashSpeed = 500f;
    public float dashCooldown;
    private Vector2 movement;
    private Vector2 mousePos;
    public Vector2 dashDir;
    bool dashing = false;

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
        if (!dashing) 
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
        Vector2 lastDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lastDirection.y, lastDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        dashDir = (mousePos - rb.position).normalized;
        Dash();
    }

    bool canDash = true;
    

    void Dash() {
        if (Input.GetKey("space") && canDash)
        {
            canDash = false;
            Debug.Log("canDAsh is true");
            dashing = true;
            StartCoroutine("dashWait");
            StartCoroutine("resetDash");
        }
    }

    IEnumerator dashWait() {
        for (int i = 1; i < 5; i++)
        {
            rb.MovePosition(rb.position + dashDir * i);
            Debug.Log(rb.position);
            yield return new WaitForFixedUpdate();
        }
        dashing = false;
        
    }

    IEnumerator resetDash() {
        yield return new WaitForSeconds(3.0f);
        canDash = true;
    }
}
