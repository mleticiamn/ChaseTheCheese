using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f; // How smoothly the camera follows the player
    public Vector3 offset; // Offset from the player's position

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;

            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
}