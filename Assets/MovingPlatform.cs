using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("How fast the platform moves")]
    public float moveSpeed = 2.0f;

    [Tooltip("How far the platform moves from its starting point")]
    public float moveDistance = 3.0f;

    [Tooltip("Check for Left/Right. Uncheck for Forward/Back.")]
    public bool moveOnXAxis = true;

    [Header("Rotation Settings")]
    [Tooltip("Speed of rotation on X, Y, and Z axes. (e.g., 0, 50, 0 spins like a carousel)")]
    public Vector3 rotationSpeed = new Vector3(0, 30, 0);

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        // Calculate the smooth movement
        float movementOffset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        if (moveOnXAxis)
        {
            transform.position = startPosition + new Vector3(movementOffset, 0, 0);
        }
        else
        {
            transform.position = startPosition + new Vector3(0, 0, movementOffset);
        }
    }

    void HandleRotation()
    {
        // Rotate the platform constantly based on the speed settings
        // Time.deltaTime ensures smooth rotation regardless of frame rate
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}