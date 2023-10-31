using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore1 : MonoBehaviour
{
    private Animator animator;
    public List<GameObject> objetosAMover; 
    private Vector3 novaPosicao;
    private bool playerInCollider = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        novaPosicao = new Vector3(0f, 7f, 0f);
    }

    void Update()
    {
        if (playerInCollider && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Slash)))
        {
            animator.SetTrigger("Animacao");
            StartCoroutine(ExecutarAcaoAposEspera(1f));
        }
    }

    IEnumerator ExecutarAcaoAposEspera(float tempoDeEspera)
    {
        yield return new WaitForSeconds(tempoDeEspera);

        foreach (GameObject objeto in objetosAMover)
        {
            objeto.transform.position = objeto.transform.position + novaPosicao;
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
