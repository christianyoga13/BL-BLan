using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_BiliardBoss : MonoBehaviour
{
    public Rigidbody[] balls; // Daftar bola yang akan dicek
    private int currentPlayer = 1; // Pemain yang mulai
    private bool isWaitingForTurn = false;

    void Update()
    {
        if (isWaitingForTurn && AllBallsStopped())
        {
            SwitchTurn();
        }
    }

    // Fungsi ini dipanggil ketika pemain memukul bola
    public void PlayerHit()
    {
        isWaitingForTurn = true;
    }

    // Cek apakah semua bola sudah berhenti
    bool AllBallsStopped()
    {
        foreach (Rigidbody ball in balls)
        {
            if (ball.velocity.magnitude > 0.1f) // Jika bola masih bergerak, tunggu
            {
                return false;
            }
        }
        return true;
    }

    // Ganti giliran pemain
    void SwitchTurn()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1; // Ganti antara pemain 1 dan 2
        Debug.Log("Giliran pemain: " + currentPlayer);
        isWaitingForTurn = false; // Siapkan giliran berikutnya
    }
}
