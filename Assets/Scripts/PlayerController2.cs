using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    //private Animator Animate; // Adicione um componente Animator

    public GameObject playerModel;

    public LifeBar barra;
    private float vida = 100;

    public void TakeDamage(float dano)
    {
        vida -= dano;
        barra.AlterarVida(vida);
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float yStore = moveDirection.y;

        // Movimento com as setas do teclado
        moveDirection = (Vector3.forward * Input.GetAxis("Vertical2")) 
            + (Vector3.right * Input.GetAxis("Horizontal2"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;

            // Salto com a tecla Enter
            if (Input.GetKeyDown(KeyCode.Return))
            {
                moveDirection.y = jumpForce;
                //Animate.SetBool("Jump", true);
            }
            else
            {
                //Animate.SetBool("Jump", false);
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxis("Horizontal2") != 0 || Input.GetAxis("Vertical2") != 0)
        {
            // Rotação do modelo (se necessário)
        }

        if (vida <= 0)
        {
            ReiniciarJogo();
        }
    }

    private void ReiniciarJogo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
