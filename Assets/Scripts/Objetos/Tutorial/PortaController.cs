using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaController : MonoBehaviour
{
    private bool portaAberta = false;

    void Start()
    {
        portaAberta = false;
    }

    public void AbrirPorta()
    {
        transform.position = new Vector3(transform.position.x, 25f, transform.position.z);
        portaAberta = true;
    }

    public void FecharPorta()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        portaAberta = false;
    }

    public bool EstaAberta()
    {
        return portaAberta;
    }
}
