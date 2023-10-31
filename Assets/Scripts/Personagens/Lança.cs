using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lança : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Inimigos inimigo = other.gameObject.GetComponent<Inimigos>();
        InimigoArena inimigos = other.gameObject.GetComponent<InimigoArena>();

        if (inimigo != null)
        {
            inimigo.TakeDamageInimigo(15f);
        }
        if (inimigos != null)
        {
            inimigos.TakeDamageInimigo(15f);
        }
    }
}
