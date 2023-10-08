using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscadaTutorial : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(transform.position.x, 8f, transform.position.z);
        }
    }
}