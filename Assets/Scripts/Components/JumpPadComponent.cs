using UnityEngine;

public class JumpPadComponent : MonoBehaviour
{
    public float jumpForce = 25f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                AudioManager.instance.PlayJumpPadSFX();
            }
        }
    }
}
