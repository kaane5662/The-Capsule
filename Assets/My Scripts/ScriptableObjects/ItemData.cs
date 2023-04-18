using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
    // Start is called before the first frame update
    public Sprite image;
    public string itemName;
    public ItemType type;
    public ActionType actType;
    public LayerMask mask;
    public enum ItemType{
        Key,
        Coin,
        
    }

    public enum ActionType{
        Open,
        AddCurrency
    }

}
