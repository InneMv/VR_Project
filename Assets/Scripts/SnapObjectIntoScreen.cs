using UnityEngine;

public class SnapObjectIntoScreen : MonoBehaviour
{
    public float distanceBehind = 1f; // Distance behind the plane to move objects
    public Collider[] triggerZones; // Trigger zones to detect objects

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object entered trigger zone: " + other.name);

        // Check if the entering object is within one of the trigger zones
        if (ArrayContainsCollider(triggerZones, other))
        {
            Debug.Log("Moving object behind plane: " + other.name);

            // Move the object behind the plane
            other.transform.position = transform.position - transform.up * distanceBehind;
        }
    }

    // Helper method to check if an array contains a specific collider
    private bool ArrayContainsCollider(Collider[] array, Collider collider)
    {
        foreach (Collider c in array)
        {
            if (c == collider)
            {
                return true;
            }
        }
        return false;
    }
}
