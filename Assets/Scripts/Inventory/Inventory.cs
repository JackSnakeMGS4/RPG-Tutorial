using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;        
    }
    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;

    public List<Item> items = new List<Item>();
    public int space = 25;

    public bool AddItem(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough space in inventory!");
                return false;
            }
            items.Add(item);

            if(onItemChangeCallback != null)
            {
                onItemChangeCallback.Invoke();
            } 
        }
        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
    }
}
