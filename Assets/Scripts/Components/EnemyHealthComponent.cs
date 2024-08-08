using UnityEngine;

public class EnemyHealthComponent : HealthComponent
{
    public int enemyValue = 50;
    private bool isDead = false;

    protected override void Die()
    {
        if (!isDead)
        {
            isDead = true;
            GameController.instance.AddScore(enemyValue);
            Destroy(gameObject);
            AudioManager.instance.PlayEnemyKillSFX();
            Debug.Log("Враг убит, начислено очков: " + enemyValue);
        }
    }
}
