using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    // Use o PlayerPrefs para rastrear o progresso de cada jogador
    public static bool IsFirstStageCompleted(string playerName)
    {
        return PlayerPrefs.GetInt(playerName + "FirstStageCompleted", 0) == 1;
    }

    public static void MarkFirstStageCompleted(string playerName)
    {
        PlayerPrefs.SetInt(playerName + "FirstStageCompleted", 1);
    }

    public static bool IsSecondStageCompleted(string playerName)
    {
        return PlayerPrefs.GetInt(playerName + "SecondStageCompleted", 0) == 1;
    }

    public static void MarkSecondStageCompleted(string playerName)
    {
        PlayerPrefs.SetInt(playerName + "SecondStageCompleted", 1);
    }
}
