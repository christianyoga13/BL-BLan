using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    // Referensi ke panel Pause Menu
    [SerializeField] private GameObject pauseMenuPanel;

    // Status game apakah sedang pause
    private bool isPaused = false;

    void Start()
    {
        // Pastikan Pause Menu tersembunyi saat game dimulai
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Pause Menu Panel tidak diatur di Inspector!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC pressed");
            TogglePauseMenu();
        }
    }


    // Fungsi untuk menampilkan/menghilangkan Pause Menu
    public void TogglePauseMenu()
    {
        isPaused = !isPaused;
        Debug.Log("TogglePauseMenu called. isPaused: " + isPaused);

        if (isPaused)
        {
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f; // Menghentikan waktu game
            Debug.Log("Game Paused.");
        }
        else
        {
            pauseMenuPanel.SetActive(false);
            Time.timeScale = 1f; // Melanjutkan waktu game
            Debug.Log("Game Resumed.");
        }
    }

    // Fungsi untuk Resume Game (dihubungkan ke tombol Resume)
    public void ResumeGame()
    {
        TogglePauseMenu();
    }

    // Fungsi untuk Kembali ke Main Menu (dihubungkan ke tombol Back to Menu)
    public void BackToMenu()
    {
        Time.timeScale = 1f; // Pastikan waktu game berjalan sebelum pindah scene
        SceneManager.LoadScene("Scenes/Menu");
    }
}
