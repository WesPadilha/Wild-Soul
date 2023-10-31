using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponte : MonoBehaviour
{
    public GameObject secondObject;
    public GameObject thirdObject;

    private bool isPlayerInTriggerZone = false;
    private Animator animator;

    void Start()
    {
        animator = secondObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPlayerInTriggerZone && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Slash)))
        {
            animator.SetTrigger("Ponte");
            thirdObject.transform.position = new Vector3(thirdObject.transform.position.x, 0.4f, thirdObject.transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTriggerZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTriggerZone = false;
        }
    }
}
