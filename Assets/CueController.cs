using UnityEngine;

public class CueController : MonoBehaviour
{
    public Transform cueBall; // Objek bola putih
    public Camera mainCamera; // Referensi ke kamera utama
    public Camera cueCamera; // Referensi ke kamera cue
    public float rotationSpeed = 100f; // Kecepatan rotasi kamera di sekitar bola
    public float moveSpeed = 5f; // Kecepatan kamera bergerak maju/mundur
    public float power = 2f; // Kekuatan pukulan

    private float horizontalInput;
    private float verticalInput;

    // Offset dan sudut kamera
    public Vector3 offset = new Vector3(0, 1, -2); // Posisi offset kamera di belakang bola
    public float downAngle = 15f; // Sudut pandang kamera menghadap bola

    void Update()
    {
        // Jika bola putih tidak null
        if (cueBall != null)
        {
            // Input horizontal dari tombol A/D untuk rotasi kamera
            horizontalInput = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; // A/D untuk horizontal
            verticalInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // W/S untuk maju/mundur

            // Kamera berputar mengelilingi bola putih menggunakan A/D (Horizontal)
            transform.RotateAround(cueBall.position, Vector3.up, horizontalInput);

            // Kamera bergerak maju dan mundur menggunakan W/S (Vertical)
            transform.position += transform.forward * verticalInput;

            // Input untuk memukul bola
            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 hitDirection = transform.forward;
                hitDirection = new Vector3(hitDirection.x, 0, hitDirection.z).normalized;

                cueBall.gameObject.GetComponent<Rigidbody>().AddForce(hitDirection * power, ForceMode.Impulse);
                
                // Pindah ke kamera utama setelah memukul bola
                SwitchToMainCamera();
            }

            // Jika tombol Space ditekan, reset posisi kamera dan beralih kembali ke kamera cue
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResetCamera();
                SwitchToCueCamera(); // Kembali ke kamera cue setelah reset
            }
        }
    }

    // Fungsi untuk mereset posisi kamera di belakang bola putih
    public void ResetCamera()
    {
        // Set posisi kamera ke offset di belakang bola putih
        transform.position = cueBall.position + offset;

        // Mengatur kamera agar melihat ke bola putih
        transform.LookAt(cueBall.position);

        // Set sudut kamera agar ada kemiringan
        transform.localEulerAngles = new Vector3(downAngle, transform.localEulerAngles.y, 0);
    }

    // Fungsi untuk beralih ke kamera utama
    void SwitchToMainCamera()
    {
        if (cueCamera != null && mainCamera != null)
        {
            cueCamera.enabled = false;  // Nonaktifkan kamera cue
            mainCamera.enabled = true;   // Aktifkan kamera utama
        }
    }

    // Fungsi untuk beralih kembali ke kamera cue
    void SwitchToCueCamera()
    {
        if (cueCamera != null && mainCamera != null)
        {
            mainCamera.enabled = false;  // Nonaktifkan kamera utama
            cueCamera.enabled = true;     // Aktifkan kembali kamera cue
        }
    }
}
