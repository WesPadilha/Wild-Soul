using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaPantano : MonoBehaviour
{
    public Transform[] objectsToMove; 
    private Vector3[] originalPositions;
    private void Start()
    {
        originalPositions = new Vector3[objectsToMove.Length];

        // Armazenar as posições originais
        for (int i = 0; i < objectsToMove.Length; i++)
        {
            originalPositions[i] = objectsToMove[i].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            for (int i = 0; i < objectsToMove.Length; i++)
            {
                objectsToMove[i].position += Vector3.up * 5f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < objectsToMove.Length; i++)
            {
                objectsToMove[i].position = originalPositions[i];
            }
        }
    }
}