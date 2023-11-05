using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tronco : MonoBehaviour
{
    public GameObject Jogadores;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Jogadores)
        {
            Jogadores.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Jogadores)
        {
            Jogadores.transform.parent = null;
        }
    }
}
