using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float dano = 20f; 
    public Transform target; 
    private CharacterController controller;
    private Vector3 moveDirection;
    private PlayerController playerController;
    private bool isTouching = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        target = GameObject.FindGameObjectWithTag("Player").transform; 
        playerController = target.GetComponent<PlayerController>();
        StartCoroutine(nameof(DanoInimigo));
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        isTouching = false; 
        
        moveDirection = (target.position - transform.position).normalized * moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var body = hit.collider;
        if(body == null)
        {
            return;
        }

        if(!body.gameObject.CompareTag("Player"))
        {
            return;
        }
            
        isTouching = true;
        DanoInimigo();
    }
    public IEnumerator DanoInimigo()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            if(isTouching)
            {
                playerController.TakeDamage(dano);
            }      
        }
    }
}