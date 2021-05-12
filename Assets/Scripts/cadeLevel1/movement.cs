using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float speed;
    private float sprintspeed;
    private float walkspeed;
    private float gravity = -0.28f;
    public CharacterController controller;
    private float translation;
    private float strafe;
    private bool grounded;
    private float vy;
    private float ay;
    private float vx;
    private float vz;
    private float friction = 1.0f;
    private float jumpHeight = 0.25f;
    public LayerMask groundMask;
    // Start is called before the first frame update
    void Start()
    {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        ay = gravity * 2;

        sprintspeed = 22.0f;
        walkspeed = 15.0f;
        speed = walkspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Sprint"))
        {
            speed = sprintspeed;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            speed = walkspeed;
        }

        vz = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        vx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        grounded = Physics.CheckSphere(transform.position, 1.5f, groundMask);

        vy += ay * Time.deltaTime;

        if (grounded) {
            Debug.Log("Grounded");
            vy = 0;
        }

        if (Input.GetButtonDown("Jump") && grounded) {
            Debug.Log("Jumping");
            vy = jumpHeight;
        }

        Debug.Log(vx + ", " + vy + ", " + vz + "Speed : " + speed);

        transform.Translate(vx, vy, vz);

    }
}
