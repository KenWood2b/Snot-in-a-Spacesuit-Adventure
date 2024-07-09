using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private MoveComponent moveComponent;
    private AttackComponent attackComponent;
    private EnemyHealthComponent healthComponent;
    private EnemyHorizontalMovement _enemyhorizontalMovement;
    private EnemyVerticalMovement _enemyverticalMovement;

    void Start()
    {
        moveComponent = GetComponent<MoveComponent>();
        attackComponent = GetComponent<AttackComponent>();
        healthComponent = GetComponent<EnemyHealthComponent>();
        _enemyhorizontalMovement = GetComponent<EnemyHorizontalMovement>();
        _enemyverticalMovement = GetComponent<EnemyVerticalMovement>();

        if (moveComponent == null)
        {
            Debug.LogError("MoveComponent не найден на " + gameObject.name);
        }

        if (attackComponent == null)
        {
            Debug.LogError("AttackComponent не найден на " + gameObject.name);
        }

        if (healthComponent == null)
        {
            Debug.LogError("EnemyHealthComponent не найден на " + gameObject.name);
        }

        if (_enemyhorizontalMovement == null && _enemyverticalMovement == null)
        {
            Debug.LogError("Должен быть назначен либо HorizontalMovement, либо VerticalMovement на " + gameObject.name);
        }
    }

    void Update()
    {
        if (_enemyhorizontalMovement != null)
        {
            _enemyhorizontalMovement.Move();
        }

        if (_enemyverticalMovement != null)
        {
            _enemyverticalMovement.Move();
        }
    }

    public void TakeDamage(int amount)
    {
        healthComponent.TakeDamage(amount);
    }
}