using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAden : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
