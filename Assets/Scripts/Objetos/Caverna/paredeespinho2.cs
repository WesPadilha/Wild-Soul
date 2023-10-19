using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paredeespinho2 : MonoBehaviour
{
    private bool playerIsNear = false;
    public GameObject Espinhos;

    void Update()
    {
        if (playerIsNear && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Slash)))
        {
            Espinhos.transform.position = new Vector3(Espinhos.transform.position.x, -30f, Espinhos.transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }
}
