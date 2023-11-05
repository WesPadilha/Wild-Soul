using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escada1 : MonoBehaviour
{
    [SerializeField]
    GameObject Escada;

    bool Aberto = false;

    private Vector3 EscadaPosOriginal;

    private void Start()
    {
        EscadaPosOriginal = Escada.transform.position;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!Aberto)
        {
            Aberto = true;
            Escada.transform.position += new Vector3(0f, -30f, 0f);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (Aberto)
        {
            Aberto = false;
            Escada.transform.position = EscadaPosOriginal;
        }
    }
}
