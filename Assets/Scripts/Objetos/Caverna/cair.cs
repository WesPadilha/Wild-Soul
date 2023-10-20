using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cair : MonoBehaviour
{
    private bool isFalling = false;
    public float delayTime = 1.5f;
    public float fallSpeed = 5.0f; // Velocidade de queda

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !isFalling)
        {
            Invoke("StartFalling", delayTime);
        }
    }

    void StartFalling()
    {
        isFalling = true;
    }

    void Update()
    {
        if (isFalling)
        {
            // Mova o objeto para baixo ao longo do eixo Y
            transform.position -= Vector3.up * fallSpeed * Time.deltaTime;
        }
    }
}