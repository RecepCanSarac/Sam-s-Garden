using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (oyuncu)
    public float smoothSpeed = 0.125f; // Takip h�z�
    public Vector3 offset; // Kameran�n hedefe g�re pozisyonu

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // �stenen pozisyon
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Yumu�ak ge�i�
        transform.position = smoothedPosition; // Kameran�n yeni pozisyonu

        transform.LookAt(target); // Kameran�n hedefe bakmas� (2D oyunlarda gerekli olmayabilir)
    }
}
