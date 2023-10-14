using UnityEngine;

public class Lever2Tutorial : MonoBehaviour
{
    public GameObject porta1;
    public GameObject porta2;
    private bool Alavanca = false;
    private bool PlayerInRange = false;
    private Vector3 PosicaoOriginal;

    void Update()
    {
        if (Alavanca)
        {
            porta1.transform.position = new Vector3(porta1.transform.position.x, porta1.transform.position.y, 725f);
            porta2.transform.position = new Vector3(porta2.transform.position.x, porta2.transform.position.y, 710f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }

    void FixedUpdate()
    {
        if (PlayerInRange && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Slash)))
        {
            Alavanca = !Alavanca; 
        }
    }
}
