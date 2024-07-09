using UnityEngine;

public class DoorComponent : MonoBehaviour
{
    private BoxCollider2D doorCollider;

    private void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        if (doorCollider == null)
        {
            Debug.LogError("BoxCollider2D не найден на двери.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null && playerController.HasKey)
            {
                doorCollider.isTrigger = true;
                Destroy(gameObject);
                AudioManager.instance.PlayDoorOpenSFX();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null && playerController.HasKey)
            {
                doorCollider.isTrigger = false;
            }
        }
    }
}
