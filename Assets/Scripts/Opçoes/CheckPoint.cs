using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class CheckPoint : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public CheckPointOption save;
    void Start()
    {
        
    }
    void Update()
    {
        var distance1 = Vector3.Distance(this.transform.position, player1.position);
        var distance2 = Vector3.Distance(this.transform.position, player2.position);
        var triggerDistance = 10f;
        bool isInDistance = distance1 < triggerDistance || distance2 < triggerDistance;
        if(isInDistance)
        {   
            save.spawnPosition = transform.position;
        }  
    }
}
