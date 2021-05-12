using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescendOrb : MonoBehaviour
{
    public Transform end;
    public Transform block;
    private bool triggered;
    private Vector3 direction;
    private float speed;
    private float minheight;
    public Transform triggerleft;
    public Transform triggerright;
    public LayerMask playermask;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        speed = 6.0f;
        direction = new Vector3(0, 1, 0);
        minheight = end.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Need to find a way to trigger but that can come later
        if (!triggered) {
            triggered = Physics.CheckCapsule(triggerleft.position, triggerright.position, 5f, playermask);
        }

        if (triggered && block.position.y > minheight && !RaiseOrb.goingUp) {
            float step = speed * Time.deltaTime;
            block.position = Vector3.MoveTowards(block.position, end.position, step);
        }
    }
}