using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueEventManager
{
    // Start is called before the first frame update

    public static event Action<string> onUpdateText;
    public static void updateText(string text){
        onUpdateText?.Invoke(text);
    }

    public static event Action onDisableText;
    public static void disableText(){
        onDisableText?.Invoke();
    }

    // Update is called once per frame
    
}
