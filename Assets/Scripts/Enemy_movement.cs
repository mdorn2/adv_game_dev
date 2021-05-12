using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movement : MonoBehaviour
{

    public float speed = 5f;

    public float gravity = -3f;

    public CharacterController controller;

    public LayerMask groundMask;

    public Transform groundCheck;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.up * 1;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (!Physics.CheckSphere(groundCheck.position, 0.5f, groundMask))
        {
            transform.Rotate(Vector3.forward * 180f);
            controller.Move(move * speed * Time.deltaTime);
        }

    }    
}
