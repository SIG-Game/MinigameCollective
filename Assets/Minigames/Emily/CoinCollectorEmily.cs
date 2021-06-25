using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectorEmily : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("CoinEmily"))
        {
            Destroy(other.gameObject);
            ScoreManagerEmily.instance.ChangeScore(coinValue);
        }
    }
}
