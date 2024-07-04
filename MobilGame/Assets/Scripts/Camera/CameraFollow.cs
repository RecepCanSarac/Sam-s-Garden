using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (oyuncu)
    public float smoothSpeed = 0.125f; // Takip hýzý
    public Vector3 offset; // Kameranýn hedefe göre pozisyonu

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Ýstenen pozisyon
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Yumuþak geçiþ
        transform.position = smoothedPosition; // Kameranýn yeni pozisyonu

        transform.LookAt(target); // Kameranýn hedefe bakmasý (2D oyunlarda gerekli olmayabilir)
    }
}
