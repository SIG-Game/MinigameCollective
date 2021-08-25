using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScriptWaleed : MonoBehaviour
{

    private float enemyMoveSpeed = 1f;
    public Transform player;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, enemyMoveSpeed * Time.deltaTime);
    }
}
