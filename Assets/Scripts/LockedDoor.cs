using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
public class LockedDoor : MonoBehaviour
{
    public bool isLocked = true;
    public UnityEvent openLevel;
    public AudioSource audioSource;

    public AudioClip lockedDoorSound;
    public void openDoor()
    {
        if(!isLocked)
            openLevel.Invoke();
        else
            audioSource.PlayOneShot(lockedDoorSound);
    }
}
