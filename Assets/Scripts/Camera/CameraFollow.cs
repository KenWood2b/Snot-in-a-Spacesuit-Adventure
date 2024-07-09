using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // ������ �� ������ ������
    public Vector3 offset; // �������� ������ ������������ ������
    public float smoothSpeed = 0.125f; // �������� ����������� �������� ������

    public float minX; // ����������� ������� �� ��� X
    public float maxX; // ������������ ������� �� ��� X
    public float minY; // ����������� ������� �� ��� Y
    public float maxY; // ������������ ������� �� ��� Y


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