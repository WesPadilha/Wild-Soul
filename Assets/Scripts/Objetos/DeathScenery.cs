using UnityEngine;

public class DeathScenery : MonoBehaviour
{
    public float dano = 500f; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController controle = other.gameObject.GetComponent<PlayerController>();
            PlayerController2 controle2 = other.gameObject.GetComponent<PlayerController2>();

            if (controle != null)
            {
                controle.TakeDamage(dano);
            }
            if (controle2 != null)
            {
                controle2.TakeDamage(dano);
            }
        }
    } 
}
