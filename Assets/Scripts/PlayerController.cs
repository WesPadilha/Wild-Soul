using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;
    public Animator Animate;
    public Transform pivot;
    public float rotateSpeed;
    public GameObject playerModel;
    private bool isAttacking = false;
    private GameObject zarabatana;
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

        zarabatana = transform.Find("Zarabatana").gameObject;
        zarabatana.SetActive(false);
    }

    void Update()
    {
        isAttacking = false;
        float yStore = moveDirection.y;
        moveDirection = (Vector3.forward * Input.GetAxis("Vertical")) 
            + (Vector3.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                Animate.SetBool("Jump", true);
            }
            else
            {
                Animate.SetBool("Jump", false);
            }   
        }
        if (Input.GetKeyDown(KeyCode.Q) && !isAttacking)
        {
            isAttacking = true;
            Animate.SetTrigger("Attack");
            zarabatana.SetActive(true);
        }
        else
        {
            zarabatana.SetActive(false);
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
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
