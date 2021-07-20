using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayerAden : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<PlayerControllerAden>().RespawnPlayer();
        }
    }
}
