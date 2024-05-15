using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCreator : MonoBehaviour
{
    void GetCharacterType(GameObject obj)
    {
        string character = obj.tag;
        switch (character)
        {
            case "neutral":
                break;
            case "negative":
                break;
            case "positive":
                break; 
        }
    }

    public void OpenCanvas()
    {
        string type = gameObject.name.Split(' ')[0];
        GameObject canvas = GameObject.Find(type + " " + "Canvas");
        bool isEnabled = canvas.GetComponent<Canvas>().enabled;
        if (isEnabled)
        {
            canvas.GetComponent<Canvas>().enabled = false;
            gameObject.tag = "Untagged";
        }
        else
        {
            canvas.GetComponent<Canvas>().enabled = true;
            gameObject.tag = "selected";
        }
    }
}
