using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public CheckPointOption CheckPoint;
    public bool useCheckPoint;
    void Start()
    {
        transform.position = useCheckPoint ? CheckPoint.spawnPosition : CheckPoint.initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
