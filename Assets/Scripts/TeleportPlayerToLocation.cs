using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerToLocation : MonoBehaviour
{

    [SerializeField] private Transform teleportDestination;
    [SerializeField] private GameObject target;
    [SerializeField] private PlayerMovement movement;

    public void teleport()
    {
        StartCoroutine("IeTeleport");
    }

    public IEnumerator IeTeleport()
    {
        movement.disabled = true;
        yield return new WaitForSeconds(0.01f);
        target.transform.position = teleportDestination.transform.position;
        yield return new WaitForSeconds(0.01f);
        movement.disabled = false;

        
    }


}
