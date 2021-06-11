using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongBallRespawner : MonoBehaviour
{
    public Text scoreText;

    int score = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            other.attachedRigidbody.velocity = Vector2.zero;
            other.GetComponent<PongBall>().Invoke("ResetBall", 1.0f);

            ++score;
            scoreText.text = score.ToString();
        }
    }
}
