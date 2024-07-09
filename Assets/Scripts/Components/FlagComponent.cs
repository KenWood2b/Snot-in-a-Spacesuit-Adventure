using UnityEngine;

public class FlagComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealthComponent playerHealth = collision.GetComponent<PlayerHealthComponent>();
            if (playerHealth != null)
            {
                playerHealth.SetRespawnPoint(transform);
                Debug.Log("Точка респауна обновлена: " + transform.position);
                AudioManager.instance.PlayCheckPointSFX();
            }
        }
    }
}

