using UnityEngine;

public class AcidController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float baseRiseSpeed = 1f;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float yStartPosition = -10f;

    private float currentSpeed;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        currentSpeed = baseRiseSpeed;
    }

    void Update()
    {


        if (ShouldRaiseAcid())
        {
            // Calculate new speed with acceleration
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);

            // Move acid upward
            transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
        }

        Vector3 position = transform.position;
        position.z = 0;
        transform.position = position;
    }

    public void ResetAcid()
    {
        transform.position = initialPosition;
        currentSpeed = baseRiseSpeed;
    }

    private bool ShouldRaiseAcid()
    {
        // Add any custom logic here (e.g., only rise when player is moving)
        return true;
    }
}