using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrigger;

    public bool isTriggerAllowed = true;
    [SerializeField] private bool triggerOnce = true;
    private bool wasTriggered = false;
    public void toggleAllowence(){isTriggerAllowed = !isTriggerAllowed;}
    public void activateTrigger()
    {
        if(triggerOnce)
        {
            if(isTriggerAllowed && !wasTriggered)
            {
                wasTriggered = true;
                onTrigger.Invoke();
            }
        }
        else if(isTriggerAllowed){onTrigger.Invoke();}
 
            
    }
}
