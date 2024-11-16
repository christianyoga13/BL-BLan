using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_pocket : MonoBehaviour
{
    public BilliardUI gameUI;  // Referensi ke script BilliardGameUI untuk meng-update status

    void OnTriggerEnter(Collider other)
    {
        // Periksa apakah objek yang masuk ke trigger adalah bola
        if (other.CompareTag("Ball"))
        {
            // Dapatkan referensi ke bola yang masuk
            Ball ball = other.GetComponent<Ball>();

            if (ball != null)
            {
                // Periksa apakah bola adalah solid atau stripe
                bool isSolid = ball.isSolid;

                // Panggil fungsi BallPocketed dari BilliardGameUI untuk mengurangi sisa bola
                gameUI.BallPocketed(isSolid);

                // Opsional: Nonaktifkan bola atau hancurkan bola setelah masuk lubang
                Destroy(other.gameObject);
            }
        }
    }
}

