using UnityEngine;

public class ProjectileAden : MonoBehaviour
{
    public Vector3 velocity;

    private void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8)
        {
            Destroy(gameObject);
        }
    }
}
