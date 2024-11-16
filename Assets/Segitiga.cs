using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segitiga : MonoBehaviour
{
    public string ballTag = "Ball";  // Pastikan bola Anda memiliki tag "Ball"
    public float ballRadius = 0.5f;  // Ukuran radius bola
    public Vector3 startPosition;    // Posisi awal bola teratas (paling depan dari segitiga)

    void Start()
    {
        SetupTriangle();
    }

    void SetupTriangle()
    {
        // Dapatkan semua bola yang memiliki tag tertentu
        GameObject[] balls = GameObject.FindGameObjectsWithTag(ballTag);

        if (balls.Length != 15)
        {
            Debug.LogError("Jumlah bola tidak sesuai dengan formasi (harus 15 bola).");
            return;
        }

        float yOffset = Mathf.Sqrt(3) * ballRadius;  // Jarak antar baris bola secara vertikal
        int ballIndex = 0;

        // Loop untuk menyusun bola dalam formasi segitiga
        for (int row = 0; row < 5; row++)  // 5 baris untuk total 15 bola
        {
            int ballsInRow = 5 - row;  // Jumlah bola per baris, menurun setiap baris

            float xOffset = -ballsInRow * ballRadius + ballRadius;  // Posisi bola pertama pada baris ini

            for (int col = 0; col < ballsInRow; col++)
            {
                if (ballIndex >= balls.Length)
                    return;

                // Hitung posisi bola dalam formasi segitiga
                Vector3 ballPosition = new Vector3(startPosition.x + xOffset + col * ballRadius * 2, 
                                                   startPosition.y, 
                                                   startPosition.z + row * yOffset);

                // Pindahkan bola ke posisi yang dihitung
                balls[ballIndex].transform.position = ballPosition;
                ballIndex++;
            }
        }
    }
}
