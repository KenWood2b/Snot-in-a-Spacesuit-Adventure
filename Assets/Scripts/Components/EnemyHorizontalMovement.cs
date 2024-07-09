using System;
using UnityEngine;

public class EnemyHorizontalMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 3f;
    private float startPositionX;
    private bool movingRight = true;

    void Start()
    {
        startPositionX = transform.position.x;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= startPositionX + moveDistance)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= startPositionX - moveDistance)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}

