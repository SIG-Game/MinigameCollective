using System.Collections;
using UnityEngine;

public class ProjectileSpawnerAden : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public Vector3 projectileVelocity;
    public float spawnTime;

    private void Start()
    {
        StartCoroutine(FireProjectiles());
    }

    IEnumerator FireProjectiles()
    {
        while (true)
        {
            GameObject instantiatedProjectile = Instantiate(projectile, firePoint.position, Quaternion.identity);
            instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = projectileVelocity;
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
