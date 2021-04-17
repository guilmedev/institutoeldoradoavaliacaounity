using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSelection : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent<GameObject> onSelectionClicked = new UnityEvent<GameObject>();

    [SerializeField] private string pickableTag = "PickUp";
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    
    private Transform _selection;

    // Update is called once per frame
    void Update()
    {

        //Leave the object
        if (_selection != null)
        {
            var selected = _selection.GetComponent<PickUpItem>();
            if (selected != null)
            {
                selected.EnableOutiline(false);
            }
        }


        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _selection = null;

        if(Physics.Raycast(ray, out var hit))
        {
            //Found something
            var selection = hit.transform;
            //It's a pickUp ...
            if(selection.CompareTag(pickableTag))
            {
                _selection = selection;
            }
        }

        if(_selection != null)
        {

            var selected = _selection.GetComponent<PickUpItem>();
            if (selected != null)
            {
                selected.EnableOutiline(true);
            }

            //Button pressed :
            if ( Input.GetMouseButtonDown(0) )
            {
                var colectable = _selection.GetComponent<IColectable>();
                //Valid object
                if(colectable != null)
                {
                    //var item = colectable.ColectItem();
                    //Debug.Log("PickedUp: " + item.itemName );

                    if (onSelectionClicked != null)
                        onSelectionClicked.Invoke( _selection.gameObject );
                }
            }
        }
    }
}
