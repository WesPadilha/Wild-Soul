using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement; 

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoRenderer;
    private bool isVideoPlaying;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        isVideoPlaying = true; 

        videoPlayer.loopPointReached += OnVideoEnd;

        videoRenderer.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isVideoPlaying)
            {
                videoPlayer.Pause();
                videoRenderer.SetActive(false);
                isVideoPlaying = false;

                SceneManager.LoadScene("tutorial");
            }
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        videoRenderer.SetActive(false);
        isVideoPlaying = false;

        SceneManager.LoadScene("tutorial");
    }
}
