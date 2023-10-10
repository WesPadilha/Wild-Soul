using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private bool isClimbing = false;
    public Transform ladder;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;
    public Animator Animate;
    public Transform pivot;
    public float rotateSpeed;
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
            Animate.SetBool("Jump", true);
        }
        else
        {
            Animate.SetBool("Jump", false);
        }
    }

    if (isClimbing)
    {
        moveDirection = new Vector3(0f, Input.GetAxis("Vertical2") * moveSpeed, 0f);
        moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale - 15f);
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow) && ladder != null)
        {
            moveDirection = Vector3.up * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && ladder != null)
        {
            moveDirection = Vector3.down * moveSpeed;
        }
        Animate.SetBool("Subir", true);
    }
    else
        {
            Animate.SetBool("Subir", false);
            moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale);
            if (controller.enabled)
            {
                controller.Move(moveDirection * Time.deltaTime);
            }

            if (Input.GetAxis("Horizontal2") != 0 || Input.GetAxis("Vertical2") != 0)
            {
                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + pivot.rotation.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(playerModel.transform.eulerAngles.y, targetAngle, ref rotateSpeed, 0.1f);
                playerModel.transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Animate.SetBool("Walking", true);
            }
            else
            {
                Animate.SetBool("Walking", false);
            }
        }

    if (Input.GetKeyDown(KeyCode.Slash) && isClimbing)
    {
        isClimbing = false;
        ladder = null;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Escada"))
        {
            isClimbing = true;
            ladder = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Escada"))
        {
            isClimbing = false;
            ladder = null;
        }
    }
}
