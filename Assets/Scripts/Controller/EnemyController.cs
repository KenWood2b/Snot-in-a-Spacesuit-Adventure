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
            Debug.LogError("MoveComponent �� ������ �� " + gameObject.name);
        }

        if (attackComponent == null)
        {
            Debug.LogError("AttackComponent �� ������ �� " + gameObject.name);
        }

        if (healthComponent == null)
        {
            Debug.LogError("EnemyHealthComponent �� ������ �� " + gameObject.name);
        }

        if (_enemyhorizontalMovement == null && _enemyverticalMovement == null)
        {
            Debug.LogError("������ ���� �������� ���� HorizontalMovement, ���� VerticalMovement �� " + gameObject.name);
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