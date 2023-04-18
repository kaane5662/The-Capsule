using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Transform cam;
    private Transform target;
    public Vector3 offset;
    private Transform worldSpaceCanvas;
    private TextMeshProUGUI promptText;
    void Start()
    {
       cam = Camera.main.transform;
    //    target = null;
    }

    // Update is called once per frame
    public void updateParent(){
        promptText = transform.GetComponent<TextMeshProUGUI>();
        target = transform.parent;
        transform.position = transform.parent.position;
        transform.SetParent(GameObject.Find("WorldCanvas").transform);
    }
    public void enableText(bool state){
        gameObject.SetActive(state);
    }

    public void updateText(string text){
        promptText.text = text;
    }
    
    void Update()
    {   
        // Debug.Log(target);
        if(target == null){return;}
        // Debug.Log("Rotate boy");
        transform.rotation = Quaternion.LookRotation(transform.position-cam.position);
        transform.position = target.position + offset;
    }
}
