using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelOptions", menuName = "levelOptions", order = 1)]
public class LevelControllerOptions : ScriptableObject
{
    public List<LevelState> Levels = new();
}
