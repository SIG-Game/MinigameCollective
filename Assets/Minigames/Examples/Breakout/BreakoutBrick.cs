using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutBrick : MonoBehaviour
{
    public BreakoutScore score;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            Destroy(gameObject);
            score.increaseScore();
        }
    }
}
