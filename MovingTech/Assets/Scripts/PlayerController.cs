using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rg;
    [SerializeField] float forcemax = 300;
    [SerializeField] float topSpeed = 500;
    Func<float, float> forceController;

    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        forceController = GetLinearFunc(topSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (input.x != 0 || input.y != 0)
        {
            var force = input * (forcemax * Time.deltaTime * FuncModule(input, forceController));
            rg.AddForce(force);
            Rotate(input);
        }
    }

    void Rotate(Vector3 input)
    {
        var angle = Vector3.SignedAngle(Vector3.up, input, Vector3.forward);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    float terminalAngle = 60;

    float FuncModule(Vector2 input, Func<float, float> f)
    {
        var angle = Vector2.Angle(rg.velocity, input);
        if (angle > terminalAngle)
        {
            return 1;
        }
        return f(rg.velocity.magnitude);
    }

    Func<float, float> GetLinearFunc(float topSpeed)
    {
        return v => (-1 / topSpeed) * v + 1;
    }
}
