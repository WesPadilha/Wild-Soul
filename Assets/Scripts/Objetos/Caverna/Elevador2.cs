using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador2 : MonoBehaviour
{
    public Transform pontoInicial;
    public Transform pontoFinal;
    public float velocidade = 1.0f;
    private bool elevadorEmMovimento = false;

    private void Update()
    {
        if (elevadorEmMovimento)
        {
            MoverElevador();
        }
    }

    public void IniciarMovimentoDoElevador()
    {
        elevadorEmMovimento = true;
    }

    private void MoverElevador()
    {
        float passo = velocidade * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pontoFinal.position, passo);

        if (transform.position == pontoFinal.position)
        {
            elevadorEmMovimento = false;
        }
    }
}
