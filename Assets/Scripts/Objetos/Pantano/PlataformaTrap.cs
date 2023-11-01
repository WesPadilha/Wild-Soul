using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTrap : MonoBehaviour
{
    public GameObject Plataforma1;
    public GameObject Plataforma2;
    private Animator animator1;
    private Animator animator2;
    private bool jogadorPerto = false;

    void Start()
    {
        // Obtenha os componentes Animator dos GameObjects em Plataforma1 e Plataforma2
        animator1 = Plataforma1.GetComponent<Animator>();
        animator2 = Plataforma2.GetComponent<Animator>();
    }

    private void Update()
    {
        if (jogadorPerto)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Slash))
            {
                // Ative o booleano nas animações dos GameObjects
                animator1.SetTrigger("1");
                animator2.SetTrigger("2");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }
}
