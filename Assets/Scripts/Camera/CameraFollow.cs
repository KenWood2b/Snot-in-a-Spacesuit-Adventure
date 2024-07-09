using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    public Vector3 offset; // Смещение камеры относительно игрока
    public float smoothSpeed = 0.125f; // Скорость сглаживания движения камеры

    public float minX; // Минимальная граница по оси X
    public float maxX; // Максимальная граница по оси X
    public float minY; // Минимальная граница по оси Y
    public float maxY; // Максимальная граница по оси Y


    void LateUpdate()
    {
        if (player != null) 
        {
            Vector3 desiredPosition = player.position + offset;
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

        }
        
    }
}