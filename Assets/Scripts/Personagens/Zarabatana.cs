using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zarabatana : MonoBehaviour
{
    [SerializeField]
    private Transform ponta;

    [SerializeField]
    private GameObject prefabProjetil;

    private float tempoUltimoDisparo;
    public float intervaloEntreDisparos = 1.0f;
    public float atrasoDisparo = 0.5f; 

    private void Start()
    {
        tempoUltimoDisparo = -intervaloEntreDisparos;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time - tempoUltimoDisparo >= intervaloEntreDisparos)
        {
            StartCoroutine(AtrasoParaAtirar());
        }
    }

    IEnumerator AtrasoParaAtirar()
    {
        tempoUltimoDisparo = Time.time; // Atualiza o tempo do último disparo imediatamente

        yield return new WaitForSeconds(atrasoDisparo);

        Atirar();
    }

    void Atirar()
    { 
        Vector3 direcaoCamera = transform.forward;

        GameObject FlechaProj = Instantiate(prefabProjetil, ponta.position, Quaternion.LookRotation(direcaoCamera));
        Projetil flecha = FlechaProj.GetComponent<Projetil>();

        RaycastHit localAtingidoRaycast;

        if (Physics.Raycast(ponta.position, direcaoCamera, out localAtingidoRaycast, Mathf.Infinity))
        {
            flecha.posicaoAlvo = localAtingidoRaycast.point;
            localAtingidoRaycast.collider.gameObject.GetComponent<Inimigos>();
        }
        else
        {
            flecha.posicaoAlvo = ponta.position + direcaoCamera * 25f;
        }
    }
}
