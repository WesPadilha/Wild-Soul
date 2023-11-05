using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoArena : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float dano = 20f;
    public float rotateSpeed = 5f;
    private CharacterController controller;
    private Vector3 moveDirection;
    private PlayerController2 playerController2;
    private PlayerController playerController;
    private bool isTouching = false;
    private float vida = 400;
    public GameObject porta;
    public float portaYCoordinate = 25f;
    private GameObject[] players;
    private float gravity = 9.81f;
    private Vector3 acceleration = Vector3.zero;

    private Animator anim;

    void Start()
    {
        vida = 400;
        controller = GetComponent<CharacterController>();
        players = GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine(DanoInimigo());
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GameObject closestPlayer = GetClosestPlayer();

        if (closestPlayer == null)
        {
            return;
        }

        playerController2 = closestPlayer.GetComponent<PlayerController2>();
        playerController = closestPlayer.GetComponent<PlayerController>();

        isTouching = false;

        Vector3 desiredMoveDirection = (closestPlayer.transform.position - transform.position).normalized;
        acceleration = desiredMoveDirection * moveSpeed;

        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        controller.Move((moveDirection + acceleration) * Time.deltaTime);

        // Rotate the enemy towards the target player
        Quaternion targetRotation = Quaternion.LookRotation(desiredMoveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        // Add animation logic here
        if (anim != null)
        {
            if (moveDirection.magnitude > 0)
            {
                anim.SetBool("Walking", true);
            }
            else
            {
                anim.SetBool("Walking", false);
            }
        }
    }

    private GameObject GetClosestPlayer()
    {
        GameObject closestPlayer = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance <= 50f && distance < closestDistance)
            {
                closestPlayer = player;
                closestDistance = distance;
            }
        }

        return closestPlayer;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var body = hit.collider;
        if (body == null)
        {
            return;
        }

        if (!body.gameObject.CompareTag("Player"))
        {
            return;
        }

        isTouching = true;
        DanoInimigo();

        // Add animation logic here
        if (anim != null)
        {
            anim.SetBool("Attack", true);
        }
    }

    public IEnumerator DanoInimigo()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (isTouching && playerController != null)
            {
                playerController.TakeDamage(dano);
            }
            if (isTouching && playerController2 != null)
            {
                playerController2.TakeDamage(dano);
            }
        }
    }

    public void TakeDamageInimigo(float damage)
    {
        this.vida -= damage;

        if (vida <= 0)
        {
            Destroy(this.gameObject);
            if (porta != null)
            {
                porta.transform.position = new Vector3(porta.transform.position.x, portaYCoordinate, porta.transform.position.z);
            }
        }
    }

    public void TakeDamage(float dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Destroy(this.gameObject);
            if (porta != null)
            {
                porta.transform.position = new Vector3(porta.transform.position.x, portaYCoordinate, porta.transform.position.z);
            }
        }
    }
}
