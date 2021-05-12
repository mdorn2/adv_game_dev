using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformForwardBack : MonoBehaviour
{
    public float speed = 1f;
    public float max = 30f;
    public float min = 15f;

    public CharacterController controller;

    public LayerMask playerMask;

    bool playerCol;

    // Start is called before the first frame update
    void Start()
    {
        max = max + transform.localPosition.z;
        min = min + transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        playerCol = Physics.CheckCapsule(transform.position, transform.position, 1f, playerMask);

        if(Input.GetAxisRaw("Vertical") > 0){
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        
        if(transform.localPosition.z > max)
        {
            speed *= -1;
        }
        if (transform.localPosition.z < min)
        {
            speed *= -1;
        }

      

    }
}
