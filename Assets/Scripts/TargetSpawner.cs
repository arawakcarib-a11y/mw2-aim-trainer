using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public int count = 6;
    public float radius = 8f;
    public float minHeight = 1f;
    public Transform spawnCenter;

    List<GameObject> spawned = new List<GameObject>();

    void Start()
    {
        if (spawnCenter == null) spawnCenter = transform;
        SpawnRing();
    }

    public void SpawnRing()
    {
        Clear();
        for (int i = 0; i < count; i++)
        {
            float angle = i * Mathf.PI * 2f / count;
            Vector3 pos = spawnCenter.position + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * radius;
            pos.y = spawnCenter.position.y + minHeight;
            GameObject go = Instantiate(targetPrefab, pos, Quaternion.identity, transform);
            spawned.Add(go);
        }
    }

    public void Clear()
    {
        foreach (var g in spawned)
        {
            if (g != null) Destroy(g);
        }
        spawned.Clear();
    }
}
