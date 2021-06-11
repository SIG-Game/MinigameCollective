using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutScore : MonoBehaviour
{
    public BreakoutBrickGenerator generator;
    public Transform playerTransform;
    public BreakoutBall ball;
    public int score;

    public void increaseScore()
    {
        ++score;

        if (score == 40)
        {
            StartCoroutine("restartGame");
        }
    }

    IEnumerator restartGame()
    {
        Time.timeScale = 0.0f;

        yield return new WaitForSecondsRealtime(1.5f);

        score = 0;
        playerTransform.position = new Vector2(0.0f, -4.2f);
        ball.ResetBall();

        generator.GenerateBricks();
        Time.timeScale = 1.0f;
    }
}
