using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coli : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
        
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
