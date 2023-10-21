using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador2 : MonoBehaviour
{
    public Transform pontoInicial;
    public Transform pontoFinal;
    public float velocidade = 1.0f;
    private bool jogadorEstaSegurandoAlavanca = false;

    private void Update()
    {
        if (jogadorEstaSegurandoAlavanca)
        {
            MoverElevador();
        }
    }

    public void IniciarMovimentoDoElevador()
    {
        jogadorEstaSegurandoAlavanca = true;
    }

    public void PararMovimentoDoElevador()
    {
        jogadorEstaSegurandoAlavanca = false;
    }

    private void MoverElevador()
    {
        float passo = velocidade * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pontoFinal.position, passo);
    }
}
