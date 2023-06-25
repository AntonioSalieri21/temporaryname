using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject actor;
    [SerializeField]
    private Vector3 pos;

    public void spawn()
    {
        Instantiate(actor, pos, Quaternion.identity);
    }
}
