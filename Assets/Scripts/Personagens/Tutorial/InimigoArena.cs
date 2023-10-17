using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InimigoArena : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float dano = 20f;
    private CharacterController controller;
    private Vector3 moveDirection;
    private PlayerController2 playerController2;
    private PlayerController playerController;
    private bool isTouching = false;
    private float vida = 100;
    public GameObject porta; 
    private GameObject[] players;

    void Start()
    {
        vida = 100;
        controller = GetComponent<CharacterController>();
        players = GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine(DanoInimigo());
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

        moveDirection = (closestPlayer.transform.position - transform.position).normalized * moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);
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
                porta.transform.position = new Vector3(porta.transform.position.x, 25f, porta.transform.position.z);
            }
        }
    }

}
