using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToLocation : MonoBehaviour
{
    [SerializeField] private Transform teleportDestination;
    [SerializeField] private GameObject target;
    public void teleport()
    {
        target.transform.position = teleportDestination.position;
    }

}
