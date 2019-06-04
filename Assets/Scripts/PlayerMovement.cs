using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Plugins.PlayerInput;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = Mathf.PI * 1.5f;

    private Vector3 rotation = new Vector3();

    private Rigidbody body;

    private float throttle;
    private float turn;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void OnThrottle(InputValue value)
    {
        throttle = value.Get<float>();
    }

    void OnTurn(InputValue value)
    {
        turn = value.Get<float>();
    }

    void FixedUpdate()
    {
        rotation.Set(
            0,
            turn,
            0
        );

        body.angularVelocity = rotation * rotationSpeed;
        body.velocity = transform.forward * throttle * speed;
    }
}
