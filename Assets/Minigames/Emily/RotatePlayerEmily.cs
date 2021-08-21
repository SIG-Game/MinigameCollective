using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerEmily : MonoBehaviour
{
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion temp = transform.rotation;
        float horiz = Input.GetAxisRaw("Horizontal");

        if(horiz < 0) {
            temp.y = 0;
            transform.rotation = temp;
        }
        if(horiz > 0) {
            temp.y = 180;
            transform.rotation = temp;
        }
    }
}
