using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscadaTutorial : MonoBehaviour
{
    public GameObject escada;

    private bool playerIsNear = false;

    void Update()
    {
        if (playerIsNear && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Slash)))
        {
            escada.transform.position = new Vector3(transform.position.x, 8f, transform.position.z - 1f);
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
