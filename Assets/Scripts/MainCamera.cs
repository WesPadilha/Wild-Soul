using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform[] playersToFollow; 
    public float smoothTime = 0.3f; 
    public Vector3 offset; 
    private Vector3 velocity;

    private Vector3 initialPosition; 

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (playersToFollow.Length == 0)
            return;

        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + new Vector3 (0, 19, -11);

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    private Vector3 GetCenterPoint()
    {
        if (playersToFollow.Length == 1)
        {
            return playersToFollow[0].position;
        }

        var bounds = new Bounds(playersToFollow[0].position, Vector3.zero);
        for (int i = 0; i < playersToFollow.Length; i++)
        {
            bounds.Encapsulate(playersToFollow[i].position);
        }

        return bounds.center;
    }

    public void ResetToInitialPosition()
    {
        transform.position = initialPosition;
    }
}