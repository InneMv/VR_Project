using UnityEngine;

public class VRJoystickMovement : MonoBehaviour
{
    public float speed = 5.0f;

    public float minX = -5f;
    public float maxX = 5f;
    public float minY = 0f; 
    public float maxY = 10f; 
    public float minZ = -10f;
    public float maxZ = 5f;

    public void HelicopterMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(verticalInput, 0.0f, -horizontalInput);

        transform.Translate(movement * speed * Time.deltaTime);
        ClampPosition();
    }

    public void HelicopterDown()
    {
        Vector3 descentMovement = Vector3.down * speed * Time.deltaTime;
        transform.Translate(descentMovement);
        ClampPosition();
    }

    public void HelicopterUp()
    {
        Vector3 ascentMovement = Vector3.up * speed * Time.deltaTime;
        transform.Translate(ascentMovement);
        ClampPosition();
    }

    // Method to constrain the helicopter's position within the boundaries
    private void ClampPosition()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            Mathf.Clamp(transform.position.z, minZ, maxZ)
        );
    }
}
