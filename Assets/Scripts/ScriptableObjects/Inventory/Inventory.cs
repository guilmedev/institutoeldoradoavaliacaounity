using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/InventoryObject")]
public class Inventory : ScriptableObject
{
    //Actions
    public ItemtEvent onItemAdded   = new ItemtEvent();
    public ItemtEvent onItemRemoved = new ItemtEvent();


    private List<IColectable> items = new List<IColectable>();

    
    public void AddItem( IColectable item )
    {
        items.Add(item);
        //Debug.Log("item" + item.ItemData().itemName + "added");
        onItemAdded?.Invoke(item.ItemData());
    }

    public void RemoveItem( IColectable item)
    {
        items.Remove(item);
        onItemRemoved?.Invoke(item.ItemData());
    }

    public void RemoveItemByData(ItemScriptableObject data)
    {        
        for (int i = 0; i < items.Count; i++)
        {
            if( items[i].ItemData() == data)
            {
                items[ i ].OnDropItem();                
                items.Remove( items[ i ] );
            }
        }
    }

}

//Custom event for items
[System.Serializable]
public class ItemtEvent : UnityEvent<ItemScriptableObject>
{
}

