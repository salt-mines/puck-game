using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = Mathf.PI * 1.5f;

    private Vector3 rotation = new Vector3();

    private Rigidbody body;

    private Player player;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }

    void FixedUpdate()
    {
        rotation.Set(
            0,
            player.turn,
            0
        );

        body.angularVelocity = rotation * rotationSpeed;
        body.velocity = transform.forward * player.throttle * speed;
    }
}
