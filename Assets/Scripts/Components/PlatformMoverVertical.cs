using UnityEngine;

public class PlatformMoverVertical : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;

    private Vector2 startPosition;
    private bool movingUp = true;
    private Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 targetPosition = movingUp ? startPosition + Vector2.up * distance : startPosition + Vector2.down * distance;
        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime));

        if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
        {
            movingUp = !movingUp;
        }
    }
}