using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaFloresta : MonoBehaviour
{
    public Transform porta;
    public GameObject[] inimigos;
    public float alturaDaPortaAberta = 10.0f;

    private int inimigosDestruidos = 0;
    private bool portaAberta = false;

    void Start()
    {
        inimigos = new GameObject[1];
    }

    void Update()
    {
        if (!portaAberta && inimigosDestruidos == inimigos.Length)
        {
            Vector3 novaPosicao = porta.position;
            novaPosicao.y = alturaDaPortaAberta;
            porta.position = novaPosicao;
            portaAberta = true;
        }
    }

    public void InimigoDestruido()
    {
        if (!portaAberta)
        {
            inimigosDestruidos++;
            
            if (inimigosDestruidos == inimigos.Length)
            {
                Vector3 novaPosicao = porta.position;
                novaPosicao.y = alturaDaPortaAberta;
                porta.position = novaPosicao;
                portaAberta = true;
            }
        }
    }
}
