using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutBallRespawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            collision.GetComponent<BreakoutBall>().Invoke("ResetBall", 1.0f);
        }
    }
}
