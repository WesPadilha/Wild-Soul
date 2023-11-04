using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataform : MonoBehaviour
{
    public Transform[] destinos; // Array de destinos para a plataforma
    public float velocidade = 5.0f; // Velocidade da plataforma

    private int indiceDestino = 0;

    private void Update()
    {
        // Verifica se a plataforma atingiu seu destino
        if (Vector3.Distance(transform.position, destinos[indiceDestino].position) <= 0.1f)
        {
            // Se chegou ao destino, atualiza o próximo destino
            indiceDestino = (indiceDestino + 1) % destinos.Length;
        }

        // Move a plataforma em direção ao destino
        Vector3 direcao = (destinos[indiceDestino].position - transform.position).normalized;
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}