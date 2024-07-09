using UnityEngine;

public class SpikeDamageComponent : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealthComponent playerHealth = collision.GetComponent<PlayerHealthComponent>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
