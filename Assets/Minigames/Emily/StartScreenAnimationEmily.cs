using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenAnimationEmily : MonoBehaviour
{
    public float movementSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * movementSpeed * Time.deltaTime;
        if (transform.position.x >= 12) {
            transform.position = new Vector3(-12, transform.position.y, transform.position.z);
        }
    }
}
