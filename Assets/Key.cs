using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    [SerializeField] private UnityEvent onKeyCollected;
    [SerializeField] public ItemData keyData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Inventory inv = other.GetComponent<Inventory>();
            Debug.Log(inv);
            inv.Add(keyData);
            Collect();
        }
    }

    public void Collect()
    {
        Destroy(gameObject);
        onKeyCollected.Invoke();
    }
}
