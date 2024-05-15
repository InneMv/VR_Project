using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.WSA;
using Cursor = UnityEngine.Cursor;

public class bluetoothmouse : MonoBehaviour

{
    public float mouseSpeed = 5f;
    public Vector3 mousePosition = new Vector3(-0.223000005f, 1.16700006f, 0.370000005f);

    private bool isDragging = false;
    private Vector3 offset; 
    private float zPos;
    private GameObject draggedObject; 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X))
            transform.position = mousePosition;

        MoveCursor();

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse press");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.forward, out hit, 10f))
            {
                Debug.Log("Hit an object: " + hit.collider.gameObject.name);
                zPos = hit.collider.gameObject.transform.position.z;
                offset = hit.collider.gameObject.transform.position - hit.point;
                isDragging = true;
                draggedObject = hit.collider.gameObject;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging == true)
            {
                isDragging = false;
                draggedObject = null; 
                Debug.Log("Released object");
            }
        }


        if (isDragging == true) 
        {
            MoveObject();
        }
    }

    void MoveCursor()
    {
        float mouseX = -Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 movement = new Vector3(mouseX, mouseY, 0f) * mouseSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void MoveObject()
    {
        Vector3 mousePos = transform.position;
        draggedObject.transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, zPos);
    }

    private void LateUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

}