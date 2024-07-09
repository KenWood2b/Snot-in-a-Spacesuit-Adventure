using UnityEngine;

public class EnemyHealthComponent : HealthComponent
{
    protected override void Die()
    {
        Destroy(gameObject);
        AudioManager.instance.PlayEnemyKillSFX();
    }
}
