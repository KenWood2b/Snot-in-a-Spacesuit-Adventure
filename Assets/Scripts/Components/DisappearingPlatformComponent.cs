using UnityEngine;

public class DisappearingPlatformComponent : MonoBehaviour
{
    public float disappearTime = 2.0f;
    private bool isPlayerOnPlatform = false;
    private float timer;

    private void Update()
    {
        if (isPlayerOnPlatform)
        {
            timer += Time.deltaTime;
            if (timer >= disappearTime)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
            timer = 0f;
        }
    }
}
