using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement; // Importe o namespace necessário

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoRenderer;
    private bool isVideoPlaying;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        isVideoPlaying = true; // Inicialize como true para que o vídeo comece sendo reproduzido.

        // Registre um método para ser chamado quando o vídeo terminar de ser reproduzido.
        videoPlayer.loopPointReached += OnVideoEnd;

        // Ative o GameObject do renderizador no início.
        videoRenderer.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isVideoPlaying)
            {
                // Se o vídeo está sendo reproduzido e o jogador pressionou a tecla de espaço, pause o vídeo e esconda-o.
                videoPlayer.Pause();
                videoRenderer.SetActive(false);
                isVideoPlaying = false;

                // Transição de cena quando o jogador pular
                SceneManager.LoadScene("tutorial");
            }
            else
            {
                // Se o vídeo não está sendo reproduzido e o jogador pressionou a tecla de espaço, reproduza o vídeo e mostre-o.
                videoPlayer.Play();
                videoRenderer.SetActive(true);
                isVideoPlaying = true;
            }
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Este método será chamado quando o vídeo terminar de ser reproduzido.
        // Você pode ocultar o vídeo aqui.
        videoRenderer.SetActive(false);
        isVideoPlaying = false;

        // Transição de cena quando o vídeo chegar ao fim
        SceneManager.LoadScene("tutorial");
    }
}
