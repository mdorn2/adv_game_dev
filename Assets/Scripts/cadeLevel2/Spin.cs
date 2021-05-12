﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 50.0f;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") > 0){
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }
}
