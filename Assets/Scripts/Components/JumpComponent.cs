using UnityEngine;

public class JumpComponent : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    //private bool isGrounded;
    private int jumpCount = 0;
    public int maxJumpCount = 2;
    private GroundColliderComponent _groundColliderComponent;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _groundColliderComponent = GetComponentInChildren<GroundColliderComponent>();
    }

    void Update()
    {
        
        if (_groundColliderComponent.IsGrounded)
        {
            jumpCount = 0;
        }
    }

    public void Jump()
    {
        if (jumpCount < maxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            AudioManager.instance.PlayJumpSFX();
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log($"JumpComponent:OnCollisionEnter2D");
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log($"JumpComponent:OnCollisionExit2D");
            isGrounded = false;
        }
    }*/
}