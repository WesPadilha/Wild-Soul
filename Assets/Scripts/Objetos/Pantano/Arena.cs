using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    bool Aberto = false;
    public GameObject Porta;
    public GameObject Objeto1;
    public GameObject Objeto2;
    private Animator animator1;
    private Animator animator2;

    void OnTriggerEnter(Collider collider)
    {
        if (!Aberto)
        {
            Aberto = true;
            Invoke("RealizarAcoesDepoisDeTempo", 3.0f);
        }
    }

    void Start()
    {
        animator1 = Objeto1.GetComponent<Animator>();
        animator2 = Objeto2.GetComponent<Animator>();
    }

    void RealizarAcoesDepoisDeTempo()
    {
        if (animator1 != null)
        {
            animator1.SetTrigger("Esquerda");
        }

        if (animator2 != null)
        {
            animator2.SetTrigger("Direita");    
        }
        
        Porta.transform.position = new Vector3(Porta.transform.position.x, 12f, Porta.transform.position.z);
    }
}
