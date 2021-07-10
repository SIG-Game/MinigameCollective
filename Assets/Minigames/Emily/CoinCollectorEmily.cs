using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectorEmily : MonoBehaviour
{
    public int coinValue = 1;
    AudioSource audio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("CoinEmily"))
        {
            audio = GetComponent<AudioSource>();
            audio.Play();
            Destroy(other.gameObject);
            ScoreManagerEmily.instance.ChangeScore(coinValue);
        }
    }
}
