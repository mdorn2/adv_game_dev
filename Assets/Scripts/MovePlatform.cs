using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
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
        max = max + transform.localPosition.y;
        min = min + transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerCol = Physics.CheckCapsule(transform.position, transform.position, 1f, playerMask);

        if(Input.GetAxisRaw("Vertical") > 0){
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        
        if(transform.localPosition.y > max)
        {
            speed *= -1;
        }
        if (transform.localPosition.y < min)
        {
            speed *= -1;
        }

        if(playerCol){
            controller.Move(Vector3.up * speed * Time.deltaTime);
        }
        
    }
}
