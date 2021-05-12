using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{

    public Transform spawnpoint;
    public Transform spawnpoint2;
    public Transform triggerleft;
    public Transform triggerright;
    public LayerMask playermask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckCapsule(triggerleft.position, triggerright.position, 5f, playermask)) {
            spawnpoint.position = spawnpoint2.position;
        }
    }
}
