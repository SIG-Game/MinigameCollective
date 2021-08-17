using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAden : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8)
        {
            Destroy(gameObject);
        }
    }
}
