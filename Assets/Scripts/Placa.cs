using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa : MonoBehaviour
{   
    [SerializeField]
    GameObject Espinhos;

    bool Aberto = false;
    void OnTriggerEnter(Collider collider)
    {
        if (!Aberto)
        {
            Aberto = true; 
            Espinhos.transform.position += new Vector3(0f, -10f, 0f);
        }   
    }
}
