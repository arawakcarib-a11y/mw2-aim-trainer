using UnityEngine;

[RequireComponent(typeof(ScoringManager))]
public class WeaponRaycaster : MonoBehaviour
{
    public float maxDistance = 1000f;
    public LayerMask targetLayer;
    public Camera cam;
    ScoringManager scoring;

    void Awake()
    {
        scoring = GetComponent<ScoringManager>();
        if (cam == null) cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        scoring.RecordShot();

        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, targetLayer))
        {
            Target t = hit.collider.GetComponentInParent<Target>();
            if (t != null)
            {
                scoring.RecordHit(t, hit.point);
                t.Hit();
            }
        }
    }
}
