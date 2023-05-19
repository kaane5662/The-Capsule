using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarSlot{

    private ItemData itemData;
    private GameObject Slot;

    private Stack<GameObject> ObjectStack = new Stack<GameObject>();
    

    public HotbarSlot(GameObject _itemObject, ItemData _itemData){
        ObjectStack.Push(_itemObject);
        itemData = _itemData;
    }
    

    public int getStackLength(){
        return ObjectStack.Count;
    }
    public void addToStack(GameObject obj){
        ObjectStack.Push(obj);
    }

    public ItemData getItemData(){
        return itemData;
    }

    public GameObject getItemFromStack(){
        return ObjectStack.Pop();
    }




}