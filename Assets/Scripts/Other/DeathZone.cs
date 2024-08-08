using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public float deathHeight = -10f;
    private PlayerHealthComponent playerHealth;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealthComponent>();
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealthComponent not found in the scene.");
        }
    }

    private void Update()
    {
        if (playerHealth != null && playerHealth.transform.position.y < deathHeight)
        {
            playerHealth.TakeDamage(playerHealth.GetCurrentHealth());
        }
    }
}
