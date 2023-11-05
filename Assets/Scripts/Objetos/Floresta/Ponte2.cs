using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponte2 : MonoBehaviour
{
    public bool jogador1Colidindo;
    public bool jogador2Colidindo;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        jogador1Colidindo = false;
        jogador2Colidindo = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1Trigger"))
        {
            jogador1Colidindo = true;
            VerificarAtivacaoAnimacao();
        }
        else if (other.CompareTag("Player2Trigger"))
        {
            jogador2Colidindo = true;
            VerificarAtivacaoAnimacao();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1Trigger"))
        {
            jogador1Colidindo = false;
            VerificarAtivacaoAnimacao();
        }
        else if (other.CompareTag("Player2Trigger"))
        {
            jogador2Colidindo = false;
            VerificarAtivacaoAnimacao();
        }
    }

    private void VerificarAtivacaoAnimacao()
    {
        if (jogador1Colidindo && jogador2Colidindo)
        {
            animator.SetTrigger("Ponte");
        }
        else
        {
            animator.ResetTrigger("Ponte");
        }
    }
}
