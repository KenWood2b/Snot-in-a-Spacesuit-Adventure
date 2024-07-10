using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColliderComponent : MonoBehaviour
{
    public bool IsGrounded { get; private set; }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
}

