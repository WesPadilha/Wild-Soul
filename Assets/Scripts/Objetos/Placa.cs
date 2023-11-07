using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa : MonoBehaviour
{
    [SerializeField]
    GameObject Espinhos;

    bool Aberto = false;

    private Vector3 espintosPosOriginal;

    private void Start()
    {
        espintosPosOriginal = Espinhos.transform.position;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!Aberto)
        {
            Aberto = true;
            Espinhos.transform.position += new Vector3(0f, -10f, 0f);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (Aberto)
        {
            Aberto = false;
            Espinhos.transform.position = espintosPosOriginal;
        }
    }
}
