using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore1 : MonoBehaviour
{
    private Animator animator;
    private bool playerInCollider = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerInCollider && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Slash)))
        {
            animator.SetTrigger("Animacao");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = false;
        }
    }
}
