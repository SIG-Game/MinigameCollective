using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        rb2d.velocity = new Vector2(Random.Range(0, 2) * 10.0f - 5.0f, Random.Range(-5.0f, 5.0f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            rb2d.velocity = new Vector2(-collision.transform.position.x * 1.3f,
                (transform.position.y - collision.transform.position.y) * 3.0f);
        }
    }
}
