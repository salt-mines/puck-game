using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = Mathf.PI * 1.5f;

    private Vector3 rotation = new Vector3();

    private Rigidbody body;

    private Player player;
    private Animator animator;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        player = GetComponent<Player>();

        body.maxAngularVelocity = 0;

        animator = GetComponentInChildren<Animator>();
    }

    void LateUpdate()
    {
        animator.SetFloat("Speed", player.throttle);
    }

    void FixedUpdate()
    {
        rotation.Set(
            0,
            player.turn * Mathf.Rad2Deg * rotationSpeed * Time.deltaTime,
            0
        );
        
        transform.Rotate(rotation);
        body.velocity = transform.forward * player.throttle * speed;
    }
}
