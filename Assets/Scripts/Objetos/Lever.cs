using UnityEngine;

public class Lever1Tutorial : MonoBehaviour
{
    public GameObject porta;
    private bool playerEstaSegurandoAlavanca = false;
    private bool playerEstaPressionandoE = false;
    private Vector3 PosicaoOriginal;

    private void Start()
    {
        PosicaoOriginal = porta.transform.position;
    }

    void Update()
    {
        if (playerEstaSegurandoAlavanca && playerEstaPressionandoE)
        {
            porta.transform.position = new Vector3(porta.transform.position.x, 25f, porta.transform.position.z);
        }
        else
        {
            porta.transform.position = PosicaoOriginal;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEstaSegurandoAlavanca = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEstaSegurandoAlavanca = false;
        }
    }

    void FixedUpdate()
    {
        playerEstaPressionandoE = Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Slash); 
    }
}
