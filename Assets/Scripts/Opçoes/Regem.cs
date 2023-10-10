using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regem : MonoBehaviour
{
    public int healthAmount = 200;
    public Animator Animate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            PlayerController2 playerController2 = other.GetComponent<PlayerController2>();

            if (playerController != null)
            {
                playerController.Heal(healthAmount); 
                Destroy(gameObject);
            }
            if (playerController2 != null)
            {
                playerController2.Heal(healthAmount); 
                Destroy(gameObject); 
            }
            
            Animate.SetBool("Regeneration", true);
        }   
    }
}
