using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UniversalTriggerCode : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrigger;
    [SerializeField] private string Tag = "Player";
    [SerializeField] private bool doOnce = true;
    [SerializeField] public Director director;
    [SerializeField] private int index;

    private bool wasTriggered = false;
    private void Start() 
    {
        
        Collider2D collider = GetComponent<BoxCollider2D>();
        

    }
    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if (other.tag == Tag && !wasTriggered && director.checkTriggerIndex(index))
        {
            if(doOnce)
            {
                wasTriggered = true;
            }
            onTrigger.Invoke();
            Debug.Log(index);
        }
    }
}
