using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Director : MonoBehaviour
{
    private int eventsNumber = 0;

    private void incTriggerIndex(){eventsNumber++;}
    public bool checkTriggerIndex(int index)
    {
        if(index == eventsNumber)
        {
            incTriggerIndex();
            return true;
        }
        return false;
    }

}
