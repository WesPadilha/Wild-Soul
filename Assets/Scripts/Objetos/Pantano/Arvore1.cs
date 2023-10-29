using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore1 : MonoBehaviour
{
    private Animator animator;
    public List<GameObject> objetosAMover; 
    private Vector3 novaPosicao;

    void Start()
    {
        animator = GetComponent<Animator>();
        novaPosicao = new Vector3(0f, 7f, 0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Slash))
        {
            animator.SetTrigger("Animacao");
            StartCoroutine(ExecutarAcaoAposEspera(1f));
        }
    }

    IEnumerator ExecutarAcaoAposEspera(float tempoDeEspera)
    {
        yield return new WaitForSeconds(tempoDeEspera);

        // Mova cada objeto na lista para a nova posição
        foreach (GameObject objeto in objetosAMover)
        {
            objeto.transform.position = objeto.transform.position + novaPosicao;
        }
    }
}
