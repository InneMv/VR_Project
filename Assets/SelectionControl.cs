using Meta.WitAi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionControl : MonoBehaviour
{
    public void SaveHuman()
    {
        GameObject selectedHuman = GameObject.FindGameObjectWithTag("selected");

        if (selectedHuman != null)
        {
            string type = selectedHuman.name.Split(' ')[0];
            GameObject canvas = GameObject.Find(type + " " + "Canvas");
            canvas.GetComponent<Canvas>().enabled = false;
            selectedHuman.DestroySafely();
            Debug.Log("Human saved: " + type + " at: " + DateTime.Now);
        }
    }
}
