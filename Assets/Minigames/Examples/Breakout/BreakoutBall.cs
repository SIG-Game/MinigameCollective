using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutBall : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    public void ResetBall()
    {
        int sign = Random.Range(0, 2) * 2 - 1;
        transform.position = new Vector3(player.transform.position.x + 0.5f * sign, -1.5f);
        rb2d.velocity = new Vector2(-2.0f * sign, -5.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            rb2d.velocity = new Vector2((transform.position.x - collision.transform.position.x) * 5.0f, 5.0f);
        }
    }
}
