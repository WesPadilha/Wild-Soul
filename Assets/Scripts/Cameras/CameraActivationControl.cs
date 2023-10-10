using UnityEngine;

public class CameraActivationControl : MonoBehaviour
{
    public Transform[] playersToFollow;
    public GameObject mainCamera;
    public GameObject[] playerCameras;
    public float activationDistance = 10f;
    private bool mainCameraActive = true;
    private MainCamera mainCameraFollow;
    private void Start()
    {
        mainCameraFollow = mainCamera.GetComponent<MainCamera>();
    }

    private void Update()
    {
        if (playersToFollow.Length < 2)
            return;

        float distance = Vector3.Distance(playersToFollow[0].position, playersToFollow[1].position);

        if (distance > activationDistance && mainCameraActive)
        {
            mainCamera.SetActive(false);

            foreach (var playerCamera in playerCameras)
            {
                playerCamera.SetActive(true);
            }

            mainCameraActive = false;
        }
        else if (distance <= activationDistance && !mainCameraActive)
        {
            mainCamera.SetActive(true);

            foreach (var playerCamera in playerCameras)
            {
                playerCamera.SetActive(false);
            }

            mainCameraActive = true;

            mainCameraFollow.ResetToInitialPosition();
        }
    }
}
