using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour , IDropHandler
{

    public UnityEvent<GameObject> onItemDropped = new UnityEvent<GameObject>();

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform panel = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint ( panel , Input.mousePosition))
        {
            //if can drop
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //can drop
            if (Physics.Raycast(ray, out hit, 50, LayerMask.GetMask("Ground")))
            {
                if ( eventData.pointerDrag != null )
                {
                    onItemDropped?.Invoke( eventData.pointerDrag );
                }
            }

        }
    }

}
