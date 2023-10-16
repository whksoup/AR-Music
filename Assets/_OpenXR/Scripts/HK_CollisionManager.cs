using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollisionInteraction
{
    public string tagA;
    public string tagB;
    public float collisionDuration = 2.0f;
}

public class HK_CollisionManager : MonoBehaviour
{
    public List<CollisionInteraction> collisionInteractions = new List<CollisionInteraction>();

    private Dictionary<string, Dictionary<string, float>> collisionStartTimes = new Dictionary<string, Dictionary<string, float>>();

    private void Awake()
    {
        // Initialize collision start times for each interaction
        foreach (var interaction in collisionInteractions)
        {
            if (!collisionStartTimes.ContainsKey(interaction.tagA))
            {
                collisionStartTimes[interaction.tagA] = new Dictionary<string, float>();
            }
            collisionStartTimes[interaction.tagA][interaction.tagB] = 0.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject objA = collision.gameObject;
        GameObject objB = collision.collider.gameObject;

        if (objA.CompareTag(objB.tag))
            return; // Avoid collisions with objects of the same tag

        string tagA = objA.tag;
        string tagB = objB.tag;

        foreach (var interaction in collisionInteractions)
        {
            if ((tagA == interaction.tagA && tagB == interaction.tagB) || (tagA == interaction.tagB && tagB == interaction.tagA))
            {
                float collisionStartTime = Time.time;
                collisionStartTimes[tagA][tagB] = collisionStartTime;
                Debug.Log("ding!");
            }



        }
    }

    private void Update()
    {
        foreach (var interaction in collisionInteractions)
        {
            float collisionStartTime = collisionStartTimes[interaction.tagA][interaction.tagB];
            if (Time.time - collisionStartTime >= interaction.collisionDuration)
            {
                Debug.Log("doooooong");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject objA = collision.gameObject;
        GameObject objB = collision.collider.gameObject;

        string tagA = objA.tag;
        string tagB = objB.tag;

        foreach (var interaction in collisionInteractions)
        {
            if ((tagA == interaction.tagA && tagB == interaction.tagB) || (tagA == interaction.tagB && tagB == interaction.tagA))
            {
                Debug.Log("uncollide");
                collisionStartTimes[tagA][tagB] = 0.0f;
            }
        }
    }
}
