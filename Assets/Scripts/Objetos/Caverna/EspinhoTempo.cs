using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhoTempo : MonoBehaviour
{
    public Transform espinho;
    public float posicaoInicialX;
    public float posicaoFinalX;
    public float duracao = 2.0f;
    public float pausaEntreMovimentos = 2.0f;

    private bool emMovimento = false;
    private float tempoInicial;

    void Start()
    {
        tempoInicial = Time.time;
    }

    void Update()
    {
        if (!emMovimento)
        {
            float tempoDecorrido = Time.time - tempoInicial;

            if (tempoDecorrido >= pausaEntreMovimentos)
            {
                emMovimento = true;
                tempoInicial = Time.time;
            }
        }
        else
        {
            float progresso = (Time.time - tempoInicial) / duracao;

            if (progresso <= 1.0f)
            {
                float novaPosicaoX = Mathf.Lerp(posicaoInicialX, posicaoFinalX, progresso);
                Vector3 novaPosicao = new Vector3(novaPosicaoX, espinho.position.y, espinho.position.z);
                espinho.position = novaPosicao;
            }
            else
            {
                emMovimento = false;
                float temp = posicaoInicialX;
                posicaoInicialX = posicaoFinalX;
                posicaoFinalX = temp;
                tempoInicial = Time.time;
            }
        }
    }
}
