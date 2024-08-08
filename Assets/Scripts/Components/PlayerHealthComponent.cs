using System.Collections;
using UnityEngine;

public class PlayerHealthComponent : HealthComponent
{
    public Transform initialRespawnPoint;
    public Transform respawnPoint;
    private GroundColliderComponent _groundColliderComponent;
    private JumpComponent _jumpComponent;
    private Rigidbody2D rb;

    protected override void Start()
    {
        respawnPoint = initialRespawnPoint;
        _groundColliderComponent = GetComponentInChildren<GroundColliderComponent>();
        _jumpComponent = GetComponentInChildren<JumpComponent>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetRespawnPoint(Transform newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    protected override void Die()
    {
        if (GameController.instance != null)
        {
            GameController.instance.LoseLife();
        }

        if (GameMaster.instance.Lives > 0)
        {
            Respawn();
            AudioManager.instance.PlayLifeLostSFX();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Respawn()
    {
        if (respawnPoint != null)
        {
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }

            transform.position = respawnPoint.position;

            if (_jumpComponent != null)
            {
                _jumpComponent.ResetJumpState();
            }

            currentHealth = maxHealth;

            if (_groundColliderComponent != null && !_groundColliderComponent.IsGrounded)
            {
                StartCoroutine(EnsureGrounded());
            }
        }
        else
        {
            Debug.LogError("Точка респауна не назначена для " + gameObject.name);
        }
    }

    private IEnumerator EnsureGrounded()
    {
        while (!_groundColliderComponent.IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, -1f);
            yield return null;
        }
    }


}
