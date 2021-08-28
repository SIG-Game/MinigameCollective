﻿using UnityEngine;

public class PlayerControllerAden : RaycastControllerAden
{
    public float movementSpeed;
    public float xAccelTimeGround;
    public float xAccelTimeAir;
    public float jumpVelocity;
    public float jumpButtonReleaseVelocity;
    public float gravity;

    public Vector2 wallJumpVel;
    public Vector2 wallJumpTowardVel;
    public Vector2 wallJumpAwayVel;

    public Transform firePoint;
    public GameObject bullet;
    public float bulletSpeed;

    int direction = 1;
    float xSmoothing;

    CollisionInfo collisions;

    Vector3 startPoint;
    Vector3 velocity;

    bool wallHanging = false;

    public override void Start()
    {
        startPoint = transform.position;
        base.Start();
    }

    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            Shoot();
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (wallHanging)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (horizontalInput == 0.0f)
                {
                    velocity.x = direction * wallJumpVel.x;
                    velocity.y = wallJumpVel.y;
                }
                else if (Mathf.Sign(horizontalInput) == direction)
                {
                    velocity.x = direction * wallJumpAwayVel.x;
                    velocity.y = wallJumpAwayVel.y;
                }
                else
                {
                    velocity.x = direction * wallJumpTowardVel.x;
                    velocity.y = wallJumpTowardVel.y;
                }

                velocity.y += gravity * Time.deltaTime * 0.5f;
                wallHanging = false;
            }
        }
        else
        {
            if (horizontalInput != 0.0f && direction != Mathf.Sign(horizontalInput))
            {
                FlipPlayer();
            }

            if (collisions.left || collisions.right)
            {
                velocity.x = 0.0f;
                xSmoothing = 0.0f; 
            }

            if (collisions.above || collisions.below)
            {
                velocity.y = 0.0f;
            }

            if (velocity.y == 0.0f)
            {
                velocity.y += gravity * Time.deltaTime * 0.5f;
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;
            }

            if (Input.GetButtonDown("Jump") && collisions.below)
            {
                velocity.y += jumpVelocity;
            }
            else if (Input.GetButtonUp("Jump") && velocity.y > jumpButtonReleaseVelocity)
            {
                velocity.y = jumpButtonReleaseVelocity;
            }

            if (Input.GetButtonDown("Wall Cling") && !collisions.below && ((direction == 1 && collisions.right) || (direction == -1 && collisions.left)))
            {
                wallHanging = true;
                velocity.y = 0.0f;
                FlipPlayer();
            }
            else
            {
                velocity.x = Mathf.SmoothDamp(velocity.x, horizontalInput * movementSpeed, ref xSmoothing, collisions.below ? xAccelTimeGround : xAccelTimeAir);
            }
        }

        Move(velocity * Time.deltaTime);
    }

    public void Move(Vector2 velocity)
    {
        collisions.Reset();
        UpdateRaycastOrigins();

        if (velocity.x != 0)
        {
            HorizontalCollisions(ref velocity);
        }

        if (velocity.y != 0)
        {
            VerticalCollisions(ref velocity);
        }

        transform.Translate(velocity);
    }

    void HorizontalCollisions(ref Vector2 velocity)
    {
        float xDir = Mathf.Sign(velocity.x);
        float xDist = Mathf.Abs(velocity.x) + skinWidth + extraInnerRayDist;

        for (int i = 0; i < numHorizontalRays; ++i)
        {
            Vector2 rayOrigin = (xDir == 1) ? raycastOrigins.bottomRight : raycastOrigins.bottomLeft;
            rayOrigin.x += -xDir * extraInnerRayDist;
            rayOrigin.y += i * horizontalRaySpacing;

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * xDir, xDist, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.right * xDir * xDist, Color.red);

            if (hit)
            {
                velocity.x = (hit.distance - skinWidth - extraInnerRayDist) * xDir;
                xDist = hit.distance;

                if (xDir == 1.0f)
                {
                    collisions.right = true;
                }
                else
                {
                    collisions.left = true;
                }
            }
        }
    }

    void VerticalCollisions(ref Vector2 velocity)
    {
        float yDir = Mathf.Sign(velocity.y);
        float yDist = Mathf.Abs(velocity.y) + skinWidth + extraInnerRayDist;

        for (int i = 0; i < numVerticalRays; ++i)
        {
            Vector2 rayOrigin = (yDir == 1) ? raycastOrigins.topLeft : raycastOrigins.bottomLeft;
            rayOrigin.x += (i * verticalRaySpacing) + velocity.x;
            rayOrigin.y += -yDir * extraInnerRayDist;

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * yDir, yDist, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.up * yDir * yDist, Color.red);

            if (hit)
            {
                velocity.y = (hit.distance - skinWidth - extraInnerRayDist) * yDir;
                yDist = hit.distance;

                if (yDir == 1.0f)
                {
                    collisions.above = true;
                }
                else
                {
                    collisions.below = true;
                }
            }
        }
    }

    void FlipPlayer()
    {
        direction *= -1;
        Vector3 newLocalScale = new Vector3(direction, 1.0f, 1.0f);
        transform.localScale = newLocalScale;
    }

    void Shoot()
    {
        Vector3 bulletPos = firePoint.transform.position;

        GameObject spawnedBullet = Instantiate(bullet, bulletPos, Quaternion.identity);

        Vector3 bulletLocalScale = spawnedBullet.transform.localScale;
        bulletLocalScale.x *= direction;

        spawnedBullet.transform.localScale = bulletLocalScale;
        spawnedBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(direction * bulletSpeed, 0.0f, 0.0f);
    }

    public void RespawnPlayer()
    {
        transform.position = startPoint;
        velocity = Vector2.zero;
        wallHanging = false;

        if (direction == -1)
        {
            FlipPlayer();
        }
    }

    public bool IsWallHanging()
    {
        return wallHanging;
    }

    struct CollisionInfo
    {
        public bool above, below, left, right;

        public void Reset()
        {
            left = right = false;
            above = below = false;
        }
    }
}
