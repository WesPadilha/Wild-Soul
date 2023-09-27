using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public bool useOffsetValues;

    public float rotateSpeed;

    public Transform pivot;

    public float maxViewAngles;
    public float minViewAngles;

    public bool invertY;

    void Start()
    {
        if (!useOffsetValues)
        {
            var position = target.position;

            offset = target.position - transform.position;

            pivot.position = new Vector3(position.x, position.y + 6f, position.z);

            pivot.transform.parent = null;

            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void LateUpdate()
    {
        var position = target.position;
        pivot.position = new Vector3(position.x, position.y + 6f, position.z);

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        if(pivot.rotation.eulerAngles.x > maxViewAngles && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngles, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngles)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngles, 0, 0);
        }

        float YAngle = pivot.eulerAngles.y;
        float XAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(XAngle, YAngle, 0);
        transform.position = target.position - (rotation * offset);

        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y -.5f, 
                transform.position.z);
        }
        transform.LookAt(pivot);

    }
}