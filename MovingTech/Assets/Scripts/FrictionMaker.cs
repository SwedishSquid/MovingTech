using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionMaker : MonoBehaviour
{
    Rigidbody2D rg;
    float activationSpeed = 0.03f;
    [SerializeField] float frictionForce = 100;
    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rg.velocity.magnitude > activationSpeed)
        {
            var force = -frictionForce * Time.deltaTime * rg.velocity.normalized;
            rg.AddForce(force);
        }
        else
        {
            rg.velocity = Vector2.zero;
        }
    }
}
