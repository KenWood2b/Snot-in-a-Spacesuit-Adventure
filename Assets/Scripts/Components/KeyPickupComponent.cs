using UnityEngine;

public class KeyPickupComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.HasKey = true;
                Destroy(gameObject);
                AudioManager.instance.PlayKeyPickupSFX();
            }
        }
    }
}
