using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class TimeStampedAudioClip
{
    public float startTimeStamp; // The start time stamp for this audio clip
    public float endTimeStamp;   // The end time stamp for this audio clip
    public AudioClip clip;       // The AudioClip itself
}

public class HKAudioManager : MonoBehaviour
{
    [SerializeField] private List<TimeStampedAudioClip> audioClips = new List<TimeStampedAudioClip>();
    private AudioClip currentClip; // The current audio clip based on time stamp

    // Update the current audio clip based on the current time stamp
    public void UpdateCurrentClip(float currentTimestamp)
    {
        //currentClip = null;

        foreach (var timeStampedClip in audioClips)
        {
            if (currentTimestamp >= timeStampedClip.startTimeStamp && currentTimestamp <= timeStampedClip.endTimeStamp)
            {
                currentClip = timeStampedClip.clip;
              
                break; // Exit the loop as soon as a matching clip is found
            }
        }
    }

    // Get the current audio clip
    public AudioClip GetCurrentClip()
    {
        Debug.Log(currentClip);
        return currentClip;
    }
}
