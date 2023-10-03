using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    private float velocidade = 50;
    private float TempoDestruir = 3f;

    [SerializeField]
    public Vector3 posicaoAlvo { get; set; }

    void Start()
    {

    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicaoAlvo, velocidade  * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Inimigos inimigo = other.gameObject.GetComponent<Inimigos>();

        if (inimigo != null)
        {
            inimigo.TakeDamageInimigo(35f);
        }

        Destroy(gameObject);
    }

    private void OnEnable()
    {
        Destroy(gameObject, TempoDestruir); 
    }
}
