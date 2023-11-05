using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedra : MonoBehaviour
{
    private Animator animator; 
    public GameObject pedra;

    private void Start()
    {
        animator = pedra.GetComponent<Animator>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (animator != null)
            {
                animator.SetTrigger("Pedra"); 
            }
        }
    }
}