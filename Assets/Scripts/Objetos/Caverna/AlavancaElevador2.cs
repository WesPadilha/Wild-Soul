using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlavancaElevador2 : MonoBehaviour
{
    public Elevador2 elevador;
    private bool isPlayerInteracting = false;
    private bool hasInteracted = false;

    private void Update()
    {
        if (isPlayerInteracting && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Slash)) && !hasInteracted)
        {
            elevador.IniciarMovimentoDoElevador();
            hasInteracted = true;
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
        }
    }
}
