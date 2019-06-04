using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = Mathf.PI * 1.5f;

    private Vector3 rotation = new Vector3();

    private Rigidbody body;
    private PlayerInput input;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        rotation.Set(
            0,
            input.horizontal,
            0
        );

        body.angularVelocity = rotation * rotationSpeed;

        body.velocity = transform.forward * input.throttle * speed;
    }
}
