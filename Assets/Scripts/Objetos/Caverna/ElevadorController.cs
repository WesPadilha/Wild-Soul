using UnityEngine;

public class ElevadorController : MonoBehaviour
{
    public Transform pontoInicial;
    public Transform pontoFinal;
    public float velocidade = 1.0f;
    private bool jogadorEstaSegurandoAlavanca = false;

    private void Update()
    {
        if (jogadorEstaSegurandoAlavanca)
        {
            MoverElevador();
        }
        else
        {
            MoverElevadorInverso();
        }
    }

    public void JogadorSegurandoAlavanca(bool segurando)
    {
        jogadorEstaSegurandoAlavanca = segurando;
    }

    private void MoverElevador()
    {
        float passo = velocidade * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pontoFinal.position, passo);
    }

    private void MoverElevadorInverso()
    {
        if (transform.position != pontoInicial.position)
        {
            float passo = velocidade * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, pontoInicial.position, passo);
        }
    }
}
