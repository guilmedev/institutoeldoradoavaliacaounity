using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasController : MonoBehaviour
{

    public UnityEvent onItemDropped = new UnityEvent();

    [Header("Canvases")]
    [SerializeField] GameObject gamePlayPanel;
    [SerializeField] GameObject initialPanel;
    [SerializeField] GameObject gamePausePanel;



    [Header("Inventory")]
    public Inventory inventory;

    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject itemInventoryPrefab;
    [SerializeField] GameObject inventoryContainer;


    [SerializeField] ItemDropHandler itemDropHandler;





    private void Awake()
    {
        inventory.onItemAdded.AddListener(OnItemAdded);

        itemDropHandler = GetComponentInChildren<ItemDropHandler>(true);
        itemDropHandler.onItemDropped.AddListener(OnItemDropped);
    }

    internal void ShowQuitPanel()
    {
        if (gamePlayPanel)
            gamePlayPanel.SetActive(false);

        if (initialPanel)
            initialPanel.SetActive(false);

        if (gamePausePanel)
            gamePausePanel.SetActive(true);
    }

    private void Start()
    {
        ShowInventoryPanel(false);
        
    }

    internal void InitGame()
    {
        if(gamePlayPanel)
            gamePlayPanel.SetActive(true);

        if(initialPanel)
            initialPanel.SetActive(false);

        if(gamePausePanel)
            gamePausePanel.SetActive(false);
    }


private void OnItemDropped(GameObject itemobject) 
    {
        //Debug.Log("DROP Item:" + itemobject.name);
        ItemInventoryUI script = itemobject.GetComponentInParent<ItemInventoryUI>();
        if (script != null)
        {
            var data = script.itemData;
            
            inventory.RemoveItemByData(data);

            Destroy(script.gameObject);
        }

        onItemDropped?.Invoke();
    }

    private void OnItemAdded( ItemScriptableObject item )
    {
        //Create item
        GameObject newItem = Instantiate(itemInventoryPrefab, inventoryContainer.transform.position, Quaternion.identity);
        newItem.transform.SetParent( inventoryContainer.transform );
        newItem.transform.localScale = Vector3.one;
        newItem.GetComponent<ItemInventoryUI>().SetData(item);
    }



    private void OnDestroy()
    {
        itemDropHandler.onItemDropped.RemoveListener(OnItemDropped);
    }

    internal void ShowInventoryPanel(bool show)
    {
        if (inventoryPanel)
            inventoryPanel.SetActive(show);
    }
}
