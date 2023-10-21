using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlavancaElevador2 : MonoBehaviour
{
    public Elevador2 elevador;
    private bool isPlayerInteracting = false;

    private void Update()
    {
        if (isPlayerInteracting && (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Slash)))
        {
            elevador.IniciarMovimentoDoElevador();
        }
        else
        {
            elevador.PararMovimentoDoElevador();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInteracting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInteracting = false;
            elevador.PararMovimentoDoElevador();
        }
    }
}
