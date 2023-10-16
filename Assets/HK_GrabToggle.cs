using UnityEngine;

public class HK_GrabToggle : MonoBehaviour
{
    // Public variable to store the KeyCode for the grab button
    public KeyCode grabKey = KeyCode.Space;

    // Global variable to track the grab state
    public float Grabba = 0.2f;

    private MeshRenderer meshRenderer;
    public Color color1 = Color.red; // Define the first color
    public Color color2 = Color.blue; // Define the second color
    public float colorChangeDuration = 1.0f; // Duration of the color change
    private float lastColorChangeTime = 0.0f;

    private void Start()
    {
        // Get the MeshRenderer component
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Grabba -= Time.deltaTime;

        // Check if Grabba is true and change color
        if (Grabba<0.1)
        {
            // Check if it's time to change colors
            if (Time.time - lastColorChangeTime >= colorChangeDuration)
            {
                // Toggle between the two colors
                if (meshRenderer != null)
                {
                    meshRenderer.material.color = color2;
                    lastColorChangeTime = Time.time;
                }
            }
        }
        else
        {
            meshRenderer.material.color = color1;
        }

    }

    // Public function to toggle the Grabba variable
    public void ToggleGrabba()
    {
        Grabba = 0.38f;
        Debug.Log("Grabbaaa");
    }

    
}
