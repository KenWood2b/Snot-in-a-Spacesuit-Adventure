using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MoveComponent moveComponent;
    private JumpComponent jumpComponent;
    private AttackComponent attackComponent;
    private PlayerHealthComponent healthComponent;

    public bool HasKey { get; internal set; }

    void Start()
    {
        moveComponent = GetComponent<MoveComponent>();
        jumpComponent = GetComponent<JumpComponent>();
        attackComponent = GetComponent<AttackComponent>();
        healthComponent = GetComponent<PlayerHealthComponent>();

        if (moveComponent == null)
        {
            Debug.LogError("MoveComponent не найден на " + gameObject.name);
        }

        if (jumpComponent == null)
        {
            Debug.LogError("JumpComponent не найден на " + gameObject.name);
        }

        if (attackComponent == null)
        {
            Debug.LogError("AttackComponent не найден на " + gameObject.name);
        }

        if (healthComponent == null)
        {
            Debug.LogError("PlayerHealthComponent не найден на " + gameObject.name);
        }
        else
        {
            Debug.Log("PlayerHealthComponent успешно инициализирован для " + gameObject.name);
        }
    }

    void Update()
    {

        if (moveComponent != null)
        {
            float moveInput = Input.GetAxis("Horizontal");
            moveComponent.Move(moveInput);
        }

        if (jumpComponent != null && Input.GetKeyDown(KeyCode.Space))
        {
            jumpComponent.Jump();
        }

        if (attackComponent != null && Input.GetKeyDown(KeyCode.F))
        {
            GameObject target = FindTarget();
            if (target != null)
            {
                attackComponent.Attack(target);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != null && collision.gameObject.CompareTag("Enemy"))
        {
            if (IsFalling() && collision.contacts[0].normal.y > 0.5f)
            {
                var enemyController = collision.gameObject.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.TakeDamage(healthComponent.GetCurrentHealth());
                }
            }
            else
            {
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(1);
                }
            }
        }
    }

    private bool IsFalling()
    {
        return GetComponent<Rigidbody2D>().velocity.y < 0;
    }

    private GameObject FindTarget()
    {
        return null;
    }
}