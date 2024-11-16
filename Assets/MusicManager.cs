using UnityEngine;
using UnityEngine.UI;  // Dibutuhkan untuk mengakses UI Button

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;  // AudioSource yang akan memainkan musik
    public Button muteButton;        // Tombol mute/unmute
    private bool isMuted = false;    // Status mute

    void Start()
    {
        // Pastikan musik mulai diputar otomatis saat game dimulai
        if (musicSource != null)
        {
            musicSource.Play();
        }

        // Menambahkan listener untuk tombol mute/unmute
        muteButton.onClick.AddListener(ToggleMute);
    }

    // Fungsi untuk mute/unmute musik
    public void ToggleMute()
    {
        isMuted = !isMuted;
        musicSource.mute = isMuted;  // Menyembunyikan suara jika muted
        
        // Mengubah teks tombol mute/unmute di sini
        Text buttonText = muteButton.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.text = isMuted ? "Unmute" : "Mute";
        }
    }

    // Fungsi untuk menghentikan musik
    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }

    // Fungsi untuk mengubah volume musik
    public void SetVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;  // Volume 0-1
        }
    }
}
