using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpItem : MonoBehaviour , IColectable 
{
    //Data
    [SerializeField] ItemScriptableObject itemData;

    Outline outline;
    Material[] myMaterials;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void Start()
    {
        outline.enabled = false;
    }


    public IColectable ColectItem()
    {
        //TODO some effects        
        this.gameObject.SetActive(false);
        return this;
    }

    public ItemScriptableObject ItemData()
    {
        return itemData;
    }

    public void OnDropItem()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast( ray , out hit , 50 , LayerMask.GetMask("Ground")))
        {
            //can drop
            this.gameObject.SetActive(true);
            this.gameObject.transform.position = hit.point;                         
        }
    }

    internal void EnableOutiline(bool enable)
    {

        if (outline)
            outline.enabled = enable;
    }



}
