using UnityEngine;

public class PlatformMoverHorizontal : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;

    private Vector2 startPosition;
    private bool movingRight = true;
    private Rigidbody2D rb;
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 targetPosition = movingRight ? startPosition + Vector2.right * distance : startPosition + Vector2.left * distance;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            movingRight = !movingRight;
        }
    }
}
