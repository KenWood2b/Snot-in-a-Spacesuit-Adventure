using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 3;
    protected int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Реализуем в дочерних классах
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}