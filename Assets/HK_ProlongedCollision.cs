using UnityEngine;

public class HK_ProlongedCollision : MonoBehaviour
{
    public string objectTagA = "TagA"; // Public variable for the first object tag
    public string objectTagB = "TagB"; // Public variable for the second object tag
    public float collisionDuration = 2.0f; // The duration in seconds for a collision to be considered prolonged

    private float collisionStartTime = 0.0f; // Time when the collision started
    private bool isColliding = false; // Flag to track if objects are in collision

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;

        // Check if the colliding object has one of the specified tags
        if (otherObject.CompareTag(objectTagA) || otherObject.CompareTag(objectTagB))
        {
            // Check if previously not colliding but now colliding
            if (!isColliding)
            {
                Debug.Log("ding!");
                isColliding = true;
                collisionStartTime = Time.time;
            }
        }
    }

    private void Update()
    {
        // Check if objects are in collision and the collision duration has passed
        if (isColliding && Time.time - collisionStartTime >= collisionDuration)
        {
            Debug.Log("doooooong");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject otherObject = collision.gameObject;

        // Check if the colliding object has one of the specified tags
        if (otherObject.CompareTag(objectTagA) || otherObject.CompareTag(objectTagB))
        {
            // Check if the objects are no longer in collision
            if (isColliding)
            {
                Debug.Log("uncollide");
                isColliding = false;
            }
        }
    }
}
