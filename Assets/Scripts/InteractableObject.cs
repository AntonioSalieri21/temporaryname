using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrigger;


    public void activateTrigger()
    {
        onTrigger.Invoke();
    }
}
