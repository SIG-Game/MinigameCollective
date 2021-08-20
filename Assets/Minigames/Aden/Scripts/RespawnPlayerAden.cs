using UnityEngine;

public class RespawnPlayerAden : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<PlayerControllerAden>().RespawnPlayer();
        }
    }
}
