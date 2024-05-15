using UnityEngine;
using UnityEngine.UI;

public class SnapObject : MonoBehaviour
{
    public Quaternion snapRotation;
    public GameObject outline;

    private float snapDistance = 0.1f;
    private AudioSource audioSource;
    private Vector3 snapPosition;
    private bool snapped = false;

    void Start()
    {
        snapPosition = outline.transform.position;
        audioSource = GetComponent<AudioSource>();  
}

    void Update()
    {
        // Check if the object is close enough to the snap position
        if (Vector3.Distance(transform.position, snapPosition) < snapDistance)
        {
            outline.SetActive(false);

            transform.position = snapPosition;
            transform.rotation = snapRotation;

            if (snapped == false)
            {
                audioSource.Play();
                snapped = true; 
            }

        }

        else
        {
            outline.SetActive(true);
            snapped = false; 
        }  
        

    }
}

