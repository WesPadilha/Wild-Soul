using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
            Animate.SetTrigger("Attacking");
            zarabatana.SetActive(true);
            StartCoroutine(nameof(WaitAttack));
            StartCoroutine(Attack());
        }

        if (isClimbing)
        {
            moveDirection = new Vector3(0f, Input.GetAxis("Vertical") * moveSpeed, 0f);
            moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale - 15f);
            controller.Move(moveDirection * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.W) && ladder != null) 
            {
                moveDirection = Vector3.up * moveSpeed;
            }
            else if (Input.GetKeyDown(KeyCode.S) && ladder != null)
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
        }

        if (Input.GetKeyDown(KeyCode.E) && isClimbing)
        {
            isClimbing = false;
            ladder = null;
        }

        if (vida <= 0)
        {
            moveSpeed = 0;
            rotateSpeed = 0;
            jumpForce = 0;
            Animate.SetBool("Morte", true);
            StartCoroutine(RestartGameAfterDelay(3f));
        }
    }

    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(1f);
        zarabatana.SetActive(false);
        isAttacking = false;
    }

    public void Heal(int amount)
    {
        vida += amount;
        vida = Mathf.Clamp(vida, 0, 100);
        barra.AlterarVida(vida);
    }

    private IEnumerator Attack()
    {
        Animate.SetLayerWeight(Animate.GetLayerIndex("Attack"), 1);
        Animate.SetTrigger("Attacking");

        yield return new WaitForSeconds(0.9f);
        Animate.SetLayerWeight(Animate.GetLayerIndex("Attack"), 0);
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
    private IEnumerator RestartGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
