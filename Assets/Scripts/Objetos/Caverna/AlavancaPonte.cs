using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlavancaPonte : MonoBehaviour
{
    private bool playerIsNear = false;
    public GameObject Porta;

    void Update()
    {
        if (playerIsNear && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Slash)))
        {
            Porta.transform.position = new Vector3(11.3f, Porta.transform.position.y   , Porta.transform.position.z);
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
