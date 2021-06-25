using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAden : MonoBehaviour
{
    public float xSpeed;
    public float jumpSpeed;

    public GameObject bullet;
    public float bulletSpeed;

    Rigidbody2D rb2d;
    int direction = 1;

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

        if (xVelocity != 0.0f && direction != Mathf.Sign(xVelocity)) {
            direction *= -1;
            Vector3 newLocalScale = new Vector3(direction, 1.0f, 1.0f);
            transform.localScale = newLocalScale;
        }

        if (Input.GetKeyDown(KeyCode.Space))
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
}
