using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbHandler : MonoBehaviour
{

    public static bool hasOrb;
    public Transform orbloc;
    public LayerMask playermask;
    public GameObject orb;

    // Start is called before the first frame update
    void Start()
    {
        hasOrb = false;
        Debug.Log("Starting Orb Handler");
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasOrb) {
            hasOrb = Physics.CheckSphere(orbloc.position, 3f, playermask);
            if (hasOrb) {
                Debug.Log("Player recieved Orb");
                orb.SetActive(false);
            }
        }
    }
}
