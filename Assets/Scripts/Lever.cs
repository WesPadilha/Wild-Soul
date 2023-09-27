using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator animacao;
    public string Player;

    private bool PlayerColission;
    private int acao;

    private void Start()
    {
        acao = 0;
        PlayerColission = false;  
    }

    private void Update()
    {
        if(PlayerColission && Input.GetKeyDown(KeyCode.E))
        {
            if(acao == 0 || acao ==1)
            {
                animacao.SetInteger("Acao", 1);
                acao = 2;
            }
            else
            {
                animacao.SetInteger("Acao", 2);
            }
        }
    }
    void OnTriggerEnter(Collider colisao)
    {
        if(colisao.gameObject.tag == Player)
        {
            PlayerColission = true;
        }
    }

    void OnTriggerExit(Collider colisao)
    {
        if(colisao.gameObject.tag == Player)
        {
            PlayerColission = false;
        }
    }
}
