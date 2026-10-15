using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Sensitivity")]
    public float sensitivity = 7.5f;
    public float adsMultiplier = 0.6f;
    [Range(0f, 1f)] public float smoothing = 0.5f;

    [Header("Cursor")]
    public bool lockCursor = true;

    [HideInInspector] public bool isADS = false;
    [HideInInspector] public Vector2 smoothedDelta = Vector2.zero;

    Vector2 smoothVelocity = Vector2.zero;

    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        isADS = Input.GetMouseButton(1) || Input.GetKey(KeyCode.LeftAlt);

        Vector2 rawDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        float currentSensitivity = sensitivity * (isADS ? adsMultiplier : 1f);
        Vector2 scaled = rawDelta * currentSensitivity;

        smoothedDelta = Vector2.Lerp(smoothVelocity, scaled, 1f - smoothing);
        smoothVelocity = smoothedDelta;
    }
}
