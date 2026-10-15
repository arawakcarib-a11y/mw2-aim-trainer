using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text hitsText;
    public Text shotsText;
    public Text accuracyText;
    public Text avgReactionText;

    ScoringManager scoring;

    void Start()
    {
        scoring = FindObjectOfType<ScoringManager>();
        UpdateStats(0, 0);
    }

    public void UpdateStats(int hits, int shots)
    {
        if (scoring == null) return;

        if (hitsText != null) hitsText.text = $"Hits: {hits}";
        if (shotsText != null) shotsText.text = $"Shots: {shots}";
        if (accuracyText != null) accuracyText.text = $"Accuracy: {scoring.GetAccuracy():0.0}%";
        if (avgReactionText != null) avgReactionText.text = $"Avg RT: {scoring.AverageReactionTime():0.000}s";
    }
}
