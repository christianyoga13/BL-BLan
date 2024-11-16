using UnityEngine;

public class WhiteBallController : MonoBehaviour
{
    private Vector3 initialPosition;
    public GameObject[] resetObjects; // Array untuk menyimpan referensi objek (table rubber, floor, tembok, dll.)

    void Start()
    {
        // Simpan posisi awal bola putih
        initialPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Cek apakah bola menyentuh salah satu objek di resetObjects
        foreach (GameObject obj in resetObjects)
        {
            if (collision.gameObject == obj)
            {
                // Kembalikan posisi bola putih ke posisi awal
                transform.position = initialPosition;

                // Pastikan bola berhenti
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                break; // Keluar dari loop setelah reset
            }
        }
    }
}
