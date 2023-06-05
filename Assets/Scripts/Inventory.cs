using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    public void Add(ItemData itemData)
    {
        InventoryItem newItem = new InventoryItem(itemData);
        inventory.Add(newItem);
    }
    public bool ContainsItem(string name)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].itemData.displayName == name)
                return true;
        }
        return false;
    }

}
