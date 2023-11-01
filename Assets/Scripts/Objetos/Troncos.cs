using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troncos : MonoBehaviour
{
    public Transform[] pontos; 
    public float velocidade = 2.0f;
    private int pontoAtual = 0;

    void Start()
    {
        MoverParaProximoPonto();
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, pontos[pontoAtual].position, velocidade * Time.deltaTime);

        if (transform.position == pontos[pontoAtual].position)
        {
            MoverParaProximoPonto();
        }
    }

    void MoverParaProximoPonto()
    {
        pontoAtual = (pontoAtual + 1) % pontos.Length; 
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}