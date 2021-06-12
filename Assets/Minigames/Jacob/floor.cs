using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    bool isLocked = false;
    public float heightToFreeze = -4.5f;
    public float movementSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= heightToFreeze) isLocked = true;

        Vector3 now = transform.position;
        now.y = heightToFreeze;
        if (isLocked) transform.position = now;

        float horizontal = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontal * movementSpeed * Time.deltaTime, 0, 0);
    }
}
