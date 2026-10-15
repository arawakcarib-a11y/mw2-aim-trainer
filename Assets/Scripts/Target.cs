using System.Collections;
using UnityEngine;

public enum TargetType { Static, Moving, Strafing }

public class Target : MonoBehaviour
{
    public TargetType type = TargetType.Static;
    public float health = 1f;
    public float respawnDelay = 1.5f;
    public bool autoRespawn = true;

    Vector3 startPos;
    public Vector3 moveAxis = Vector3.right;
    public float moveAmplitude = 1f;
    public float moveSpeed = 1f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (type == TargetType.Moving)
        {
            transform.position = startPos + moveAxis.normalized * Mathf.Sin(Time.time * moveSpeed) * moveAmplitude;
        }
        else if (type == TargetType.Strafing)
        {
            transform.position = startPos + moveAxis.normalized * ((Time.time * moveSpeed) % (moveAmplitude * 2) - moveAmplitude);
        }
    }

    public void Hit()
    {
        StartCoroutine(HitFeedback());
    }

    IEnumerator HitFeedback()
    {
        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            Color orig = rend.material.color;
            rend.material.color = Color.yellow;
            yield return new WaitForSeconds(0.12f);
            rend.material.color = orig;
        }

        if (autoRespawn)
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(respawnDelay);
            gameObject.SetActive(true);
        }
    }
}
