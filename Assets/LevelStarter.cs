using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField]
    private LevelControllerOptions levelControllerOptions;
    void Start()
    {
        levelControllerOptions.Levels = new()
        {
            new LevelState { Index = 0, Name = "pantano", IsComplete = false },
            new LevelState { Index = 1, Name = "caverna", IsComplete = false }
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
