using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChooser : MonoBehaviour
{
    public string nextScene;
    public string playerName; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (nextScene == "caverna")
            {
                ProgressManager.MarkFirstStageCompleted(playerName);
            }
            else if (nextScene == "pantano")
            {
                ProgressManager.MarkSecondStageCompleted(playerName);
            }
            
            SceneManager.LoadScene(nextScene);
        }
    }
}
