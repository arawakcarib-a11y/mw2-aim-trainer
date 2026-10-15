using UnityEngine;

public class GameController : MonoBehaviour
{
    public TargetSpawner spawner;
    public ScoringManager scoring;

    void Start()
    {
        if (spawner == null) spawner = FindObjectOfType<TargetSpawner>();
        if (scoring == null) scoring = FindObjectOfType<ScoringManager>();

        if (spawner != null)
        {
            spawner.SpawnRing();
        }

        if (scoring != null)
        {
            scoring.ResetSession();
        }
    }
}
