using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutBrickGenerator : MonoBehaviour
{
    public GameObject brick;
    public BreakoutScore score;

    void Start()
    {
        GenerateBricks();
    }

    public void GenerateBricks()
    {
        for (int i = 0; i < 5; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                GameObject newBrick = Instantiate(brick, new Vector3(transform.position.x + 2.1f * j, transform.position.y + 0.95f * i), Quaternion.identity);
                newBrick.GetComponent<BreakoutBrick>().score = score;
            }
        }
    }
}
