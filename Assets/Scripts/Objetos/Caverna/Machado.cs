using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machado : MonoBehaviour
{
    public float dano = 500f; 
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController controle = other.gameObject.GetComponent<PlayerController>();
            PlayerController2 controle2 = other.gameObject.GetComponent<PlayerController2>();

            if (controle != null)
            {
                controle.TakeDamage(dano);
            }
            if (controle2 != null)
            {
                controle2.TakeDamage(dano);
            }

            if (animator != null)
            {
                animator.SetTrigger("Ataque");
            }
        }
    }
}