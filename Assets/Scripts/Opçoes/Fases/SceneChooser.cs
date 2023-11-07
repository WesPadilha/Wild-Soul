using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChooser : MonoBehaviour
{
    [SerializeField]
    private LevelControllerOptions levels;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            var sceneName = SceneManager.GetActiveScene().name;
            var level = levels.Levels.FirstOrDefault(x => x.Name == sceneName);
            levels.Levels.Remove(level);
            level.IsComplete = true;
            levels.Levels.Add(level);
            var nextLevel = levels.Levels.FirstOrDefault(x => !x.IsComplete);
            if (nextLevel != null)
            {
                SceneManager.LoadScene(nextLevel.Name);
            }
            else
            {
                SceneManager.LoadScene("Floresta");
            }
        }
    }
}
