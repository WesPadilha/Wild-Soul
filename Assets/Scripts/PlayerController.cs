using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private bool isClimbing = false;
    private Transform ladder;
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
        
        if (Input.GetKeyDown(KeyCode.E) && isClimbing)
        {
            StartClimbing();
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            if (hit.collider.CompareTag("Escada"))
            {
                isClimbing = true;
                ladder = hit.collider.transform;
            }
        }
        else
        {
            isClimbing = false;
            ladder = null;
        }

        if (vida <= 0)
        {
            ReiniciarJogo();
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

    private void StartClimbing()
    {
        controller.enabled = false;

        Vector3 climbPosition = ladder.position + Vector3.up * 1.5f;
        transform.position = climbPosition;

        transform.rotation = Quaternion.LookRotation(-ladder.forward);

        Animate.SetBool("Subir", true);

        moveDirection.y = 0f;
    }
    private void StopClimbing()
    {
        controller.enabled = true;

        Animate.SetBool("Subir", false);

        transform.rotation = Quaternion.identity;
    }

    private void ReiniciarJogo()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
}
