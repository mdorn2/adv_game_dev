using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slopeFriction : MonoBehaviour
{
    
    Vector3 hitNormal;

    public float slideFriction = 0.3f;

    public CharacterController player;
    bool isSlope;

    float x;
    float z;
    void OnControllerColliderHit (ControllerColliderHit hit) {
        hitNormal = hit.normal;
    }

    // Update is called once per frame
    void Update()
    {
        isSlope = (Vector3.Angle (Vector3.up, hitNormal) <= 45f);

        if(isSlope){  
            x += (1f - hitNormal.y) * hitNormal.x * (1f - slideFriction);
            z += (1f - hitNormal.y) * hitNormal.z * (1f - slideFriction);
        }

        Vector3 move = Vector3.Normalize(transform.right * x + transform.forward * z);

        player.Move(move * Time.deltaTime);
    }
}
