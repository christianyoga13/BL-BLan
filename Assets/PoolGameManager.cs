using UnityEngine;

public class PoolGameManager : MonoBehaviour
{
    public Transform cueStick;  // Referensi ke stik
    public Transform whiteBall; // Referensi ke bola putih
    public float stopSpeedThreshold = 0.05f;  // Kecepatan di bawah ini dianggap berhenti
    public float cueDistanceFromBall = 0.6f;  // Jarak stik dari bola putih setelah reset
    private bool isWhiteBallMoving = false;   // Apakah bola putih sedang bergerak

    private Rigidbody whiteBallRb;

    void Start()
    {
        // Dapatkan Rigidbody bola putih
        whiteBallRb = whiteBall.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Cek apakah bola putih masih bergerak atau sudah berhenti
        if (whiteBallRb.velocity.magnitude > stopSpeedThreshold)
        {
            isWhiteBallMoving = true;
        }
        else if (isWhiteBallMoving && whiteBallRb.velocity.magnitude <= stopSpeedThreshold)
        {
            // Ketika bola putih berhenti, reset posisi stik
            isWhiteBallMoving = false;
            ResetCueStickPosition();
        }
    }

    void ResetCueStickPosition()
    {
        // Reset posisi stik di belakang bola putih
        Vector3 newCuePosition = whiteBall.position - whiteBall.forward * cueDistanceFromBall;
        newCuePosition.y = cueStick.position.y; // Pertahankan tinggi stik (agar tetap di atas meja)
        cueStick.position = newCuePosition;

        // Reset rotasi stik agar menghadap ke arah bola putih
        cueStick.LookAt(whiteBall.position);

        // Jika cue adalah parent kamera, rotasi kamera juga akan direset secara otomatis
    }
}
