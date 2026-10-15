using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;
    public float pitchMin = -85f;
    public float pitchMax = 85f;

    InputHandler input;
    float yaw = 0f;
    float pitch = 0f;

    void Awake()
    {
        input = GetComponent<InputHandler>();
        if (cameraTransform == null) cameraTransform = Camera.main.transform;
        Vector3 angles = transform.localEulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void Update()
    {
        Vector2 delta = input.smoothedDelta;
        yaw += delta.x;
        pitch -= delta.y;
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        transform.localRotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
