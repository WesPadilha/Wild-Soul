using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CheckPoint", menuName = "CheckPoint", order = 0)]

public class CheckPointOption : ScriptableObject
{
    public Vector3 spawnPosition;
    public Vector3 initialPosition;
}
