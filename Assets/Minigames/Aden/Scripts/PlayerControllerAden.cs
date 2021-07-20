using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAden : MonoBehaviour
{
    public float xSpeed;
    public float jumpSpeed;

    public GameObject bullet;
    public float bulletSpeed;

    public float groundedRayLength;

    Rigidbody2D rb2d;
    LayerMask platformMask;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        platformMask = LayerMask.GetMask("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        float xVelocity = xSpeed * Input.GetAxisRaw("Horizontal");
        float yVelocity = rb2d.velocity.y;

        if (xVelocity != 0.0f && direction != Mathf.Sign(xVelocity)) {
            direction *= -1;
            Vector3 newLocalScale = new Vector3(direction, 1.0f, 1.0f);
            transform.localScale = newLocalScale;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            yVelocity = jumpSpeed;
        }

        rb2d.velocity = new Vector2(xVelocity, yVelocity);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 bulletPos = transform.position;
            bulletPos.x += direction;

            GameObject spawnedBullet = Instantiate(bullet, bulletPos, Quaternion.identity);

            Vector3 bulletLocalScale = spawnedBullet.transform.localScale;
            bulletLocalScale.x *= direction;

            spawnedBullet.transform.localScale = bulletLocalScale;
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(direction * bulletSpeed, 0.0f, 0.0f);
        }
    }

    bool isGrounded()
    {
        Bounds bounds = GetComponent<BoxCollider2D>().bounds;
        Vector2 bottomLeft = new Vector2(bounds.center.x - bounds.extents.x, bounds.center.y - bounds.extents.y);
        Vector2 bottomRight = new Vector2(bounds.center.x + bounds.extents.x, bounds.center.y - bounds.extents.y);

        RaycastHit2D bottomLeftHit = Physics2D.Raycast(bottomLeft, Vector2.down, groundedRayLength, platformMask);
        RaycastHit2D bottomRightHit = Physics2D.Raycast(bottomRight, Vector2.down, groundedRayLength, platformMask);

        /* For debugging:
        Color bottomLeftRayColor = Color.red;
        Color bottomRightRayColor = Color.red;
        if (bottomLeftHit.collider != null)
        {
            bottomLeftRayColor = Color.green;
        }
        if (bottomRightHit.collider != null)
        {
            bottomRightRayColor = Color.green;
        }
        Debug.DrawRay(bottomLeft, Vector2.down * groundedRayLength, bottomLeftRayColor);
        Debug.DrawRay(bottomRight, Vector2.down * groundedRayLength, bottomRightRayColor); */

        return bottomLeftHit.collider != null || bottomRightHit.collider != null;
    }

    public void RespawnPlayer()
    {
        transform.position = Vector3.zero;
        rb2d.velocity = Vector3.zero;
    }
}
