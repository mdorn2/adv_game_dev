using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseOrb : MonoBehaviour
{
    public Transform end;
    public Transform block;
    private bool triggered;
    private Vector3 direction;
    private float speed;
    private float maxheight;
    public Transform triggerleft;
    public Transform triggerright;
    public LayerMask playermask;

    public static bool goingUp;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        speed = 6.0f;
        direction = new Vector3(0, 1, 0);
        maxheight = end.position.y;
        goingUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Need to find a way to trigger but that can come later
        if (!triggered && OrbHandler.hasOrb) {
            Debug.Log("Checking trigger now");
            triggered = Physics.CheckCapsule(triggerleft.position, triggerright.position, 2f, playermask);
            if (triggered) {
                goingUp = true;
                Debug.Log("Return triggered");
            }
        }

        if (triggered && block.position.y < maxheight) {
            Debug.Log("Moving");
            float step = speed * Time.deltaTime;
            block.position = Vector3.MoveTowards(block.position, end.position, step);
        }
    }
}
