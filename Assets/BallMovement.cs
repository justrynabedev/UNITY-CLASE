using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] float moveForce = 10f;
    [SerializeField] float jumpForce = 6f;
    [SerializeField] float groundCheckExtra = 0.1f;

    Rigidbody rb;
    float radius;
    float horizontal;
    float vertical;
    bool jumpRequested;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        radius = GetComponent<Collider>().bounds.extents.y;
    }

    void Update()
    {
        horizontal = 0f;
        vertical = 0f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) horizontal += 1f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) horizontal -= 1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) vertical += 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) vertical -= 1f;

        if (Input.GetKeyDown(KeyCode.Space))
            jumpRequested = true;
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(horizontal, 0f, vertical) * moveForce);

        if (jumpRequested && IsGrounded())
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        jumpRequested = false;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, radius + groundCheckExtra);
    }
}
