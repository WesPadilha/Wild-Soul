using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTempo : MonoBehaviour
{
    public Transform espinho;
    public float posicaoInicialY;
    public float posicaoFinalY; 
    public float duracao = 2.0f;
    public float pausaEntreMovimentos = 2.0f;

    private bool emMovimento = false;
    private float tempoInicial;

    void Start()
    {
        tempoInicial = Time.time;
    }

    void FixedUpdate()
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
                float novaPosicaoY = Mathf.Lerp(posicaoInicialY, posicaoFinalY, progresso); 
                Vector3 novaPosicao = new Vector3(espinho.position.x, novaPosicaoY, espinho.position.z); 
                espinho.position = novaPosicao;
            }
            else
            {
                emMovimento = false;
                float temp = posicaoInicialY; 
                posicaoInicialY = posicaoFinalY; 
                posicaoFinalY = temp; 
                tempoInicial = Time.time;
            }
        }
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
