using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscadaTutorial : MonoBehaviour
{
    public GameObject escada;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            escada.transform.position = new Vector3(escada.transform.position.x, 7f, escada.transform.position.z);
        }
    }
}