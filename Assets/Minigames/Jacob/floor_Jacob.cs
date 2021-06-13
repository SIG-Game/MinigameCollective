using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor_Jacob : MonoBehaviour
{
    bool isLocked = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float heightToFreeze = -4.5f;
    public float movementSpeed = 1f;
    public float jumpForce = 25;

    private float distGround;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        if (rb2d == null) Debug.Log("BIG ISSUE");

        anim = this.GetComponent<Animator>();
        if (anim == null) Debug.Log("BIG ISSUE");

        distGround = GetComponent<CapsuleCollider2D>().bounds.extents.y;
    }

    bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distGround + 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= heightToFreeze) isLocked = true;
        float jump = Input.GetAxis("Jump");

        // Vector3 now = transform.position;
        // now.y = heightToFreeze;
        // if (isLocked && jump <= 0) transform.position = now;

        float horizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontal) > 0.2) anim.SetBool("Running", true);
        else anim.SetBool("Running", false);

        if (horizontal < 0) transform.localScale = new Vector3(-1f, 1, 1);
        else transform.localScale = Vector3.one;


        transform.position = transform.position + new Vector3(horizontal * movementSpeed * Time.deltaTime, 0, 0);


        if (jump > 0 && isGrounded())
        {
            Debug.Log("Jumping");
            anim.SetBool("Jumping", true);
            // Add raycast ground check so cannot jump midair or hold to super jump
            rb2d.AddForce(transform.up * jumpForce / 100, ForceMode2D.Impulse);
        }
    }
}
