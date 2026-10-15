using System.IO;
using System.Text;
using UnityEngine;

public class SessionLogger : MonoBehaviour
{
    StringBuilder sb = new StringBuilder();
    string sessionFolder;

    void Awake()
    {
        sessionFolder = Path.Combine(Application.persistentDataPath, "AimTrainerSessions");
        if (!Directory.Exists(sessionFolder)) Directory.CreateDirectory(sessionFolder);
        StartSession();
    }

    public void StartSession()
    {
        sb.Clear();
        sb.AppendLine("time,targetX,targetY,targetZ,hitX,hitY,hitZ");
    }

    public void LogHit(float time, Vector3 targetPos, Vector3 hitPos)
    {
        sb.AppendLine($"{time:F4},{targetPos.x:F3},{targetPos.y:F3},{targetPos.z:F3},{hitPos.x:F3},{hitPos.y:F3},{hitPos.z:F3}");
    }

    public void SaveSession(string filename = null)
    {
        if (string.IsNullOrEmpty(filename))
            filename = $"session_{System.DateTime.Now:yyyyMMdd_HHmmss}.csv";

        string path = Path.Combine(sessionFolder, filename);
        File.WriteAllText(path, sb.ToString());
        Debug.Log($"Session saved: {path}");
    }
}
