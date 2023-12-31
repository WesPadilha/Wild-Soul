using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string gameNameLevel;
    [SerializeField] private GameObject MenuInicial;
    [SerializeField] private GameObject Opcoes;
    [SerializeField]
    private LevelControllerOptions levelControllerOptions;

    public void Play()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public void Options()
    {
        Opcoes.SetActive(true);
        
    }

    public void CloseOptions()
    {
        Opcoes.SetActive(false);

    }

    public void LeaveGame()
    {
        Application.Quit();
        
    }
}