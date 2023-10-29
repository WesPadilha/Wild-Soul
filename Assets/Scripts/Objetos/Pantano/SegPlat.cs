using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegPlat : MonoBehaviour
{
    bool Aberto = false;
    public GameObject plat;

    void OnTriggerEnter(Collider collider)
    {
        if (!Aberto)
        {
            Aberto = true;
            Invoke("MudarPosicaoDaPorta", 1.5f); 
        }
    }

    void MudarPosicaoDaPorta()
    {
        plat.transform.position = new Vector3(plat.transform.position.x, -50f, plat.transform.position.z);
    }
}