using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaController : MonoBehaviour
{
    private bool portaAberta = false;

    void Start()
    {
        // Inicialmente, a porta está fechada
        portaAberta = false;
    }

    public void AbrirPorta()
    {
        // Mude a posição Y da porta para 25f para abri-la
        transform.position = new Vector3(transform.position.x, 25f, transform.position.z);
        portaAberta = true;
    }

    public void FecharPorta()
    {
        // Mude a posição Y da porta para 0f para fechá-la
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        portaAberta = false;
    }

    public bool EstaAberta()
    {
        return portaAberta;
    }
}
