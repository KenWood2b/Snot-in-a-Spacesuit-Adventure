using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveComponent : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float movementSmoothing = 0.05f;
    private Rigidbody2D rb;
    private Vector2 velocity = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float moveInput)
    {
        Vector2 targetVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}