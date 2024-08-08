using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int coinValue = 10;
    public int diamondValue = 50;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Coin"))
            {
                GameController.instance.AddScore(coinValue);
                AudioManager.instance.PlayCoinSFX();
            }
            else if (gameObject.CompareTag("Diamond"))
            {
                GameController.instance.AddScore(diamondValue);
                AudioManager.instance.PlayDiamondSFX();
            }
            Destroy(gameObject);
        }
    }
}
