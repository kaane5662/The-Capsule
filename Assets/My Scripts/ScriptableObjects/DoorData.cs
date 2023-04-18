using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Scriptable Object/DoorData")]
public class DoorData : ScriptableObject
{
    // Start is called before the first frame update
    public int unlocksNeeded;
    public KeyRequired key;
    public ActionType action;
    public enum KeyRequired {
        GoldenKey, SilverKey, BronzeKey
    }

    public enum ActionType {
        OpenDoor
    }


    
}
