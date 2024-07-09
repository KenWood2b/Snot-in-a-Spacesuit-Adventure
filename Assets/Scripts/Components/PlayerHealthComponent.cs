using UnityEngine;

public class PlayerHealthComponent : HealthComponent
{
    public Transform initialRespawnPoint;
    public Transform respawnPoint;

    private void Start()
    {
        respawnPoint = initialRespawnPoint;
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

        if (GameController.instance.GetLives() > 0)
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
            transform.position = respawnPoint.position;
            currentHealth = maxHealth;
        }
        else
        {
            Debug.LogError("Точка респауна не назначена для " + gameObject.name);
        }
    }
}
