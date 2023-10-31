using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cair : MonoBehaviour
{
    private bool isFalling = false;
    private float downSpeed = 0.0f;

    // Variável para controlar o atraso antes de começar a cair.
    private float delayBeforeFalling = 1.0f;

    private void FixedUpdate()
    {
        if (isFalling)
        {
            downSpeed += Time.deltaTime / 20.0f;
            Vector3 newPosition = transform.position - new Vector3(0, downSpeed, 0);
            transform.position = newPosition;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartFallingDelay());
            collider.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        collider.transform.SetParent(null);
    }

    IEnumerator StartFallingDelay()
    {
        yield return new WaitForSeconds(delayBeforeFalling);

        isFalling = true;
        Destroy(gameObject, 10.0f);
    }
}
