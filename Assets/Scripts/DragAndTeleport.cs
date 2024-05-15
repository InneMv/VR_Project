using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using TS.ColorPicker;
using TS.ColorPicker.Demo;
using UnityEngine;

public class DragAndTeleport : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private ColorPicker _colorPicker;

    public Collider planeCollider;
    public GameObject screen;
    public float teleportDistance = 0.2f;

    private bool inScreen = false;
    private Color _color;

    void Start()
    {
        GetComponentInChildren<HandGrabInteractable>().enabled = true;
        GetComponentInChildren<DistanceHandGrabInteractable>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other == planeCollider && inScreen == false)
        {
            GetComponentInChildren<HandGrabInteractable>().enabled = false;
            TeleportBehindPlane();
            startColorPicker();
            Debug.Log("Object entered the screen.");
            GetComponentInChildren<DistanceHandGrabInteractable>().enabled = true;
            inScreen = true;            
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other == planeCollider && inScreen == true)
        {
            Debug.Log("Object exited the screen.");
            GetComponentInChildren<DistanceHandGrabInteractable>().enabled = false;
            GetComponentInChildren<HandGrabInteractable>().enabled = true;
            inScreen = false;
            removeColorPicker();
        }
    }

    public void TurnObjectLeft()
    {
        if(inScreen == true)
        {
            transform.Rotate(0, -90f, 0);
        }
    }

    public void TurnObjectRight()
    {
        if (inScreen == true)
        {
            transform.Rotate(0, 90f, 0);
        }
    }
    void TeleportBehindPlane()
    {
        Vector3 teleportPosition = transform.position;
        MeshRenderer screenRenderer = screen.GetComponent<MeshRenderer>();
        teleportPosition.x = (screenRenderer.bounds.max.x + screenRenderer.bounds.min.x) / 2f;
        teleportPosition.y = -0.1f;
        teleportPosition.z = planeCollider.bounds.max.z - teleportDistance;
        transform.position = teleportPosition;
        transform.rotation = Quaternion.identity;
    }

    void startColorPicker()
    {
        _colorPicker.OnChanged.AddListener(ColorPicker_OnChanged);
        _colorPicker.OnSubmit.AddListener(ColorPicker_OnSubmit);
        _colorPicker.OnCancel.AddListener(ColorPicker_OnCancel);
        _color = _renderer.material.color;
        _colorPicker.Open(_color);
    }

    void removeColorPicker()
    {
        _colorPicker.OnChanged.RemoveAllListeners();
        _colorPicker.OnSubmit.RemoveAllListeners();
        _colorPicker.OnCancel.RemoveAllListeners();
    }

    private void ColorPicker_OnChanged(Color color)
    {
        _renderer.material.color = color;
    }
    private void ColorPicker_OnSubmit(Color color)
    {
        _color = color;
    }
    private void ColorPicker_OnCancel()
    {
        _renderer.material.color = _color;
    }
}
