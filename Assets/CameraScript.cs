using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;  // Referensi ke objek yang akan diikuti (bola putih)
    public Vector3 offset;    // Offset kamera dari target

    void LateUpdate()
    {
        if (target != null)
        {
            // Pindahkan posisi kamera mengikuti target dengan offset
            transform.position = target.position + offset;

            // Optional: Mengarahkan kamera ke target
            transform.LookAt(target.position);
        }
    }
}
