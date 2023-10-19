using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Transform pontoA; 
    public Transform pontoB; 
    public float velocidade = 2.0f; 
    private Vector3 pontoDestino;

    void Start()
    {
        pontoDestino = pontoB.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pontoDestino, velocidade * Time.deltaTime);

        if (transform.position == pontoDestino)
        {
            TrocarDestino();
        }
    }

    void TrocarDestino()
    {
        if (pontoDestino == pontoA.position)
        {
            pontoDestino = pontoB.position;
        }
        else
        {
            pontoDestino = pontoA.position;
        }
    }
}