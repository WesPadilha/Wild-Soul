using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas : MonoBehaviour
{
    bool Aberto = false;
    public GameObject Porta;
    public float novaPosicaoY = 4.1f; 

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
        Vector3 novaPosicao = new Vector3(Porta.transform.position.x, novaPosicaoY, Porta.transform.position.z);
        Porta.transform.position = novaPosicao;
    }
}
