using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryUI : MonoBehaviour
{
    [SerializeField] private Image itemImage;

    private ItemScriptableObject item;

    public ItemScriptableObject itemData => item;
        
    internal void SetData(ItemScriptableObject item)
    {
        //this.item = Instantiate(item);
        this.item = item;

        if (itemImage != null )
        {
            itemImage.sprite = this.item?.itemSprite;
        }
    }
}
