using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector2 minBounds; // Minimum X and Y bounds (left and bottom edges of the level)
    public Vector2 maxBounds; // Maximum X and Y bounds (right and top edges of the level)

    private Camera cam; // Reference to the camera
    private float halfCameraWidth; // Half of the camera's width in world units
    private float halfCameraHeight; // Half of the camera's height in world units

    void Start()
    {
        // Get the camera component
        cam = GetComponent<Camera>();

        // Calculate half of the camera's width and height in world units
        halfCameraHeight = cam.orthographicSize;
        halfCameraWidth = halfCameraHeight * cam.aspect;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the camera's desired position
            float targetX = player.position.x;
            float targetY = player.position.y;

            // Clamp the camera's position within the bounds
            float clampedX = Mathf.Clamp(targetX, minBounds.x + halfCameraWidth, maxBounds.x - halfCameraWidth);
            float clampedY = Mathf.Clamp(targetY, minBounds.y + halfCameraHeight, maxBounds.y - halfCameraHeight);

            // Update the camera's position
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}