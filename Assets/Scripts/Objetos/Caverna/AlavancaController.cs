using UnityEngine;

public class AlavancaController : MonoBehaviour
{
    public ElevadorController elevador;

    private bool jogadorPerto = false;

    private void Update()
    {
        if (jogadorPerto && (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Slash)))
        {
            elevador.JogadorSegurandoAlavanca(true);
        }
        else
        {
            elevador.JogadorSegurandoAlavanca(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            elevador.JogadorSegurandoAlavanca(false);
        }
    }
}
