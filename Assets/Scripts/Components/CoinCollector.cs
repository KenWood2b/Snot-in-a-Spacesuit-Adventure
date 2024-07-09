using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int coinValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.instance.AddScore(coinValue);
            Destroy(gameObject);
            AudioManager.instance.PlayCoinSFX();

        }
    }
}
