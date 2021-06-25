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
        if(Input.GetKeyDown(KeyCode.A)) {
            temp.y = 0;
            transform.rotation = temp;
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            temp.y = 180;
            transform.rotation = temp;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            temp.y = 0;
            transform.rotation = temp;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            temp.y = 180;
            transform.rotation = temp;
        }
    }
}
