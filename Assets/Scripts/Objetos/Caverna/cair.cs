using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cair : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Desativar o Rigidbody no início para que o objeto esteja imóvel
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        // Verifica se o objeto que colidiu é o jogador (você pode definir isso de acordo com as suas necessidades)
        if (other.gameObject.CompareTag("Player"))
        {
            // Ativa o Rigidbody para permitir movimento físico
            rb.isKinematic = false;
            rb.useGravity = true; // Ativa a gravidade
        }
    }
}