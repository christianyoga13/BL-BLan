using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BilliardUI : MonoBehaviour
{
    public Text solidBallsText;  // Referensi ke Text UI untuk Sisa Bola Solid
    public Text stripeBallsText;  // Referensi ke Text UI untuk Sisa Bola Stripe
    public Text playerTurnText;   // Referensi ke Text UI untuk Giliran Pemain
    public Text controlsText;     // Referensi ke Text UI untuk Controls

    private int solidBallsLeft = 7;  // Jumlah sisa bola solid
    private int stripeBallsLeft = 7;  // Jumlah sisa bola stripe
    private int currentPlayer = 1;    // Giliran pemain (1 atau 2)

    void Start()
    {
        // Inisialisasi controls text
        controlsText.text = "Controls: WASD to move, Space to charge";

        // Update UI pertama kali
        UpdateSolidBallsText();
        UpdateStripeBallsText();
        UpdatePlayerTurnText();
    }

    void UpdateSolidBallsText()
    {
        solidBallsText.text = "Solid Balls Left: " + solidBallsLeft;
    }

    void UpdateStripeBallsText()
    {
        stripeBallsText.text = "Stripe Balls Left: " + stripeBallsLeft;
    }

    void UpdatePlayerTurnText()
    {
        playerTurnText.text = "Player Turn: Player " + currentPlayer;
    }

    // Fungsi ini dipanggil saat bola solid masuk lubang
    public void BallPocketed(bool isSolid)
    {
        if (isSolid)
        {
            solidBallsLeft--;
            UpdateSolidBallsText();
        }
        else
        {
            stripeBallsLeft--;
            UpdateStripeBallsText();
        }
    }

    // Fungsi ini dipanggil saat giliran pemain berubah
    public void SwitchPlayerTurn()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        UpdatePlayerTurnText();
    }
}

