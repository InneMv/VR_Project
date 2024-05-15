using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ClickSimulateTest : GraphicRaycaster
{
    public Transform cursor;


    // override the Raycast method from the GraphicRaycaster 
    // this method is responsible for performing the raycast for UI elements 
    public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
    {
        eventData.position = Camera.main.WorldToScreenPoint(cursor.position);  // raycast originates from cursor
        base.Raycast(eventData, resultAppendList);                             // updated raycasting 
    }

}
