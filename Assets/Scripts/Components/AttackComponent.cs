using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public int damage = 1;

    public void Attack(GameObject target)
    {
        HealthComponent healthComponent = target.GetComponent<HealthComponent>();
        if (healthComponent != null)
        {
            healthComponent.TakeDamage(damage);
        }
    }
}
