using System.Collections.Generic;
using UnityEngine;

public class ScoringManager : MonoBehaviour
{
    public int shots = 0;
    public int hits = 0;

    List<float> reactionTimes = new List<float>();
    Dictionary<Target, float> spawnTimes = new Dictionary<Target, float>();

    public UIManager uiManager;
    public SessionLogger logger;

    void Start()
    {
        if (uiManager == null) uiManager = FindObjectOfType<UIManager>();
        if (logger == null) logger = FindObjectOfType<SessionLogger>();
    }

    public void RecordShot()
    {
        shots++;
        uiManager?.UpdateStats(hits, shots);
    }

    public void RecordHit(Target target, Vector3 hitPoint)
    {
        hits++;
        uiManager?.UpdateStats(hits, shots);

        if (spawnTimes.TryGetValue(target, out float spawnTime))
        {
            float rt = Time.time - spawnTime;
            reactionTimes.Add(rt);
            spawnTimes.Remove(target);
        }

        logger?.LogHit(Time.time, target.transform.position, hitPoint);
    }

    public void NotifyTargetSpawned(Target target)
    {
        spawnTimes[target] = Time.time;
    }

    public float GetAccuracy()
    {
        return shots == 0 ? 0f : (float)hits / shots * 100f;
    }

    public float AverageReactionTime()
    {
        if (reactionTimes.Count == 0) return 0f;
        float sum = 0f;
        foreach (var t in reactionTimes) sum += t;
        return sum / reactionTimes.Count;
    }

    public void ResetSession()
    {
        shots = 0;
        hits = 0;
        reactionTimes.Clear();
        spawnTimes.Clear();
        uiManager?.UpdateStats(hits, shots);
        logger?.StartSession();
    }
}
