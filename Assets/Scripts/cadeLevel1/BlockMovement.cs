using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    private Transform child;
    private float speed;
    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        speed = 20.0f;
    }

    void MoveEach()
     {
        Debug.Log("Running MoveEach");
        int children = transform.childCount;
        for (int i = 0; i < children; ++i) {
            child = transform.GetChild(i);
            child.Translate(0.0f, 0.0f, (speed * Time.deltaTime));
            Debug.Log("Shifted");

            if (child.position.z > 20)  {
                Debug.Log("Need to Reset");
                destination = new Vector3(Random.Range(-25.0f, 25.0f), child.position.y, -320);
                child.position = destination;
            }
        }
     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0) {
            MoveEach();
        }
    }
}
