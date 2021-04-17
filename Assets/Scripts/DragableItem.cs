using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    //public Mesh mesh;
    //public Material material;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }

    //private void Update()
    //{
    //    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Graphics.DrawMesh(mesh, pos, Quaternion.identity, material, 0);
    //}
}
