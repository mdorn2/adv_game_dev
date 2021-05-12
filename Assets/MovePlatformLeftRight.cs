using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformLeftRight : MonoBehaviour
{
    public float speed = 5f;
    public float max = 10f;
    public float min = -10f;

    public CharacterController controller;

    public LayerMask playerMask;

    bool playerCol;

    // Start is called before the first frame update
    void Start()
    {
        max = max + transform.localPosition.x;
        min = min + transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        playerCol = Physics.CheckCapsule(transform.position, transform.position, 1f, playerMask);

        if(Input.GetAxisRaw("Vertical") > 0){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        if(transform.localPosition.x > max)
        {
            speed *= -1;
        }
        if (transform.localPosition.x < min)
        {
            speed *= -1;
        }

      

    }
}
