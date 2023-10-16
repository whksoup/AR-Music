using UnityEngine;

public class HKAudioManagerController : MonoBehaviour
{
    public HKAudioManager[] audioManagers; // References to AudioManager instances
    public float updateInterval = 1.0f; // Interval at which to update the audio managers (in seconds)

    private float currentTimeStamp = 0.0f;
    private float timer = 0.0f;

    private void Start()
    {
        // Initialize the timer
        timer = 0.0f;
    }

    private void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to update the audio managers
        if (timer >= updateInterval)
        {
            // Update the current timestamp (replace this with your actual timestamp retrieval logic)
            // For demonstration purposes, we use a simple increment here.
            currentTimeStamp += updateInterval;

            // Update the audio managers
            foreach (var audioManager in audioManagers)
            {
                audioManager.UpdateCurrentClip(currentTimeStamp);
            }

            // Reset the timer
            timer = 0.0f;
        }
    }
}
