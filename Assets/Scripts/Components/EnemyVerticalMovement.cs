using UnityEngine;

public class EnemyVerticalMovement : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;
    private bool movingUp = true;
    private float initialPositionY;

    void Start()
    {
        initialPositionY = transform.position.y;
    }

    void Update()
    {
        Move();
    }
    public void Move()
    {
        if (movingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (transform.position.y >= initialPositionY + distance)
        {
            movingUp = false;
        }
        else if (transform.position.y <= initialPositionY - distance)
        {
            movingUp = true;
        }
    }
}