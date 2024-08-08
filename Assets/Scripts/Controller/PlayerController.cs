using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MoveComponent moveComponent;
    private JumpComponent jumpComponent;
    private AttackComponent attackComponent;
    private PlayerHealthComponent healthComponent;
    private Rigidbody2D rb;
    /*private FixedJoint2D fixedJoint;
    private bool isOnPlatform;*/

    public bool HasKey { get; internal set; }

    void Start()
    {
        moveComponent = GetComponent<MoveComponent>();
        jumpComponent = GetComponent<JumpComponent>();
        attackComponent = GetComponent<AttackComponent>();
        healthComponent = GetComponent<PlayerHealthComponent>();
        rb = GetComponent<Rigidbody2D>();
       /* fixedJoint = gameObject.AddComponent<FixedJoint2D>();
        fixedJoint.enabled = false;*/

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
            /*fixedJoint.enabled = false;
            isOnPlatform = false;*/
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            fixedJoint.connectedBody = collision.rigidbody;
            fixedJoint.enabled = true;
            isOnPlatform = true;
        }*/
        if (collision.gameObject.CompareTag("Enemy"))
        {
            bool isFalling = IsFalling();

            if (isFalling && collision.contacts[0].normal.y > 0.5f)
            {
                var enemyController = collision.gameObject.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    int damageToDeal = 1;
                    enemyController.TakeDamage(damageToDeal);
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

    /*void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            fixedJoint.enabled = false;
            isOnPlatform = false;
        }
    }*/

    private bool IsFalling()
    {
        return GetComponent<Rigidbody2D>().velocity.y < 0;
    }

    private GameObject FindTarget()
    {
        return null;
    }
}