using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interactable : MonoBehaviour
{

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public ItemData key;
    [SerializeField]public GameObject player;
    private Inventory inv;
    
    void Update()
    {
        if(isInRange)
        {
        
            
            if(Input.GetKeyDown(interactKey) && inv.ContainsItem(key.displayName))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            inv = collision.GetComponent<Inventory>();
            isInRange = true;
            Debug.Log("Is in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Not in range");
        }
    }
}
