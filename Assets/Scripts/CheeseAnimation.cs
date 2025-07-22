using UnityEngine;

public class CheeseAnimation : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float speed = 1f;

    private Vector3 startPosition;

    void Start()
    {
        // Save the starting position of the cheese
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the cheese up and down using a sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}