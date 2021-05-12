using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proj : MonoBehaviour
{

    public float speed = 100f;

    public LayerMask groundMask;
    public LayerMask enemyMask;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (Physics.CheckSphere(transform.position, 0.6f, groundMask))
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
