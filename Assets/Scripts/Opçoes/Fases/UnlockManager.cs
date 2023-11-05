using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockManager : MonoBehaviour
{
    void Start()
    {
        if (ProgressManager.IsFirstStageCompleted("Akacheta") && ProgressManager.IsFirstStageCompleted("Makawi") &&
            ProgressManager.IsSecondStageCompleted("Akacheta") && ProgressManager.IsSecondStageCompleted("Makawi"))
        {
            SceneManager.LoadScene("Floresta");
        }
    }
}
