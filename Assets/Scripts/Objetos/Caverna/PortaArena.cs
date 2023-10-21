using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaArena : MonoBehaviour
{
    bool Aberto = false;
    public GameObject Porta;

    void OnTriggerEnter(Collider collider)
    {
        if (!Aberto)
        {
            Aberto = true;
            Invoke("MudarPosicaoDaPorta", 3.0f); 
        }
    }

    void MudarPosicaoDaPorta()
    {
        Porta.transform.position = new Vector3(Porta.transform.position.x, -14f, Porta.transform.position.z);
    }
}
