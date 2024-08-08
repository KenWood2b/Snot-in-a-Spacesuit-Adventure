using UnityEngine;

public class JumpComponent : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
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
    public void ResetJumpState()
    {
        jumpCount = 0;
    }

}