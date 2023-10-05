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
    public Transform pivot;
    public GameObject playerModel;
    public LifeBar barra;
    private float vida = 200;

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

        moveDirection = (Vector3.forward * Input.GetAxis("Vertical2")) 
            + (Vector3.right * Input.GetAxis("Horizontal2"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxis("Horizontal2") != 0 || Input.GetAxis("Vertical2") != 0)
        {
            float targetRotation = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + pivot.eulerAngles.y;
            playerModel.transform.rotation = Quaternion.Euler(0, targetRotation, 0);
        }

        if (vida <= 0)
        {
            ReiniciarJogo();
        }
    }
    public void Heal(int amount)
    {
        vida += amount;
        vida = Mathf.Clamp(vida, 0, 200); 
        barra.AlterarVida(vida); 
    }

    private void ReiniciarJogo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
