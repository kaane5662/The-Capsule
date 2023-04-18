using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Object/NoteData")]
public class NoteData : ScriptableObject
{
    public string header;
    public string description;
    public string closing;
    public string objectiveUpdate;
    public NoteAction noteAction;

    public enum NoteAction{
        Objective, Story, Secret
    }
}
