using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsCanvas;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            AbrirOpcoes();
        }

    }

    public void IniciarJogo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
    }


    public void AbrirOpcoes()
    {
        bool canOpen = !(GameObject.FindGameObjectsWithTag("Option").Length > 0);

        if (canOpen)
        {
            optionsCanvas.SetActive(true); 
        }
    }

    public void FecharOpcoes()
    {
        optionsCanvas.SetActive(false);
    }

    public void IniciarGameplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void Sair()
    {
        Debug.Log("Saindo...");
        Application.Quit();
    }




}
