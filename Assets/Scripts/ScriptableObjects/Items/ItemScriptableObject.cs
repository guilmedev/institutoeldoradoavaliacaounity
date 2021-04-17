using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/CreateItem")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
}
