using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Item : MonoBehaviour
{   
    
    
    
    public ItemData itemData;
    public void destroyObject(){
        Destroy(transform.gameObject, .5f);
    }
    public ItemData getData(){
        return itemData;
    }





}
