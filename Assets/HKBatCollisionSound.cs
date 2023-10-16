using UnityEngine;

public class HKBatCollisionSound : MonoBehaviour
{
    public HKAudioManager audioManager1; // Reference to AudioManager for material 1 (e.g., "Wood")
    public HKAudioManager audioManager2; // Reference to AudioManager for material 2 (e.g., "Metal")

    private HKAudioManager currentAudioManager; // Reference to the current AudioManager
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to the bat GameObject
        audioSource = GetComponent<AudioSource>();

        // Make sure the AudioSource is not playing at the start
        audioSource.Stop();

        // Initialize the currentAudioManager based on your initial material (e.g., "Wood")
        currentAudioManager = audioManager1;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger collision involves the wooden bat
        if (other.gameObject.CompareTag("Wood"))
        {
            // Switch to the AudioManager responsible for "Wood" material
            currentAudioManager = audioManager1;
        }
        else if (other.gameObject.CompareTag("Metal"))
        {
            // Switch to the AudioManager responsible for "Metal" material
            currentAudioManager = audioManager2;
        }

        // Get the AudioClip from the current AudioManager
        AudioClip clip = currentAudioManager.GetCurrentClip();

        if (clip != null)
        {
            // Set the audio clip and play it
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioClip not found in the current AudioManager.");
        }
    }
}
