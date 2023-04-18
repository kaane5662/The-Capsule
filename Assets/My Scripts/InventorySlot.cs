using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySlot{

    public ItemData data;
    public List<GameObject> items = new List<GameObject>();

    public int maxCount = 10;

    public int itemCount;

    public TextMeshProUGUI itemCountText;


    public InventorySlot(ItemData _data, GameObject _item, TextMeshProUGUI _itemCountText){
        itemCount++;
        items.Add(_item);
        data = _data;
        itemCountText = _itemCountText;
        updateItemCountText();
    }

    void updateItemCountText(){
        itemCountText.text = itemCount.ToString();
    }

    public bool addItemOfSameType(GameObject _item){
        if(itemCount <= maxCount){
            itemCount++;
            items.Add(_item);
            updateItemCountText();
            return true;
        }
        return false;
    }

    public GameObject removeItem(){
        Debug.Log(items);
        GameObject returnItem = items[items.Count-1];
        items.RemoveAt(items.Count-1);
        itemCount--;
        updateItemCountText();
        return returnItem;
    }


    
     

    

}