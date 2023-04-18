using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class EquipEvent : MonoBehaviour
{
    private UnityEvent _equip;
    void OnPointerEnter(){
        _equip.Invoke();
        if(Input.GetKeyDown(KeyCode.F)){
            Debug.Log("Pressing F.");
        }
         
    }

    // Start is called before the first frame update
    
}
