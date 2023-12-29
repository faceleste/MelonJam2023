using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesconfiometroManager : MonoBehaviour
{

    public Slider slider;
    public GameObject backgroundOBJ;
    public GameObject faceOBJ;

    public PlayerMove player;
    [Header("BG")]
    public Sprite muitoDesconfiado;
    public Sprite desconfiado;
    public Sprite confiando;
    [Header("Face")]
    public Sprite faceConfianca;
    public Sprite faceNeutral;
    public Sprite faceDesconfianca;
    [Header("Scripts")]
    public BoboScript boboscript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DrenarConfianca", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        manageDesconfianca(slider.value);
    }

    void manageDesconfianca(float valorDesconfianca)
    {




        if (boboscript.isViewPlayer)
        {
            if (player.isPlayerInvisible)
            {
                Debug.Log("Invisivel");
            }
            else
            {
                Debug.Log("Olhou pq tá curioso");
                slider.value += 20;
            }
            boboscript.isViewPlayer = false;
        }

        if (valorDesconfianca > 70 && valorDesconfianca <= 100)
        {
            AltaDesconfianca();
        }
        else if (valorDesconfianca < 40)
        {
            BaixaDesconfianca();
        }
        else
        {
            MediaDesconfianca();
        }


        if (valorDesconfianca == 100)
        {
            GameOver();
        }

    }

    void AltaDesconfianca()
    {
        MudarCorSlider("red");
        backgroundOBJ.GetComponent<Image>().sprite = muitoDesconfiado;
        faceOBJ.GetComponent<Image>().sprite = faceDesconfianca;
        boboscript.timeToView = 1;
        //mudar cor do slider e do fill do slider


    }

    void BaixaDesconfianca()
    {
        MudarCorSlider("green");
        backgroundOBJ.GetComponent<Image>().sprite = confiando;
        faceOBJ.GetComponent<Image>().sprite = faceConfianca;
        boboscript.timeToView = 15;
    }

    void MediaDesconfianca()
    {
        MudarCorSlider("yellow");
        boboscript.timeToView = 5;
        backgroundOBJ.GetComponent<Image>().sprite = desconfiado;
        faceOBJ.GetComponent<Image>().sprite = faceNeutral;

    }

    void MudarCorSlider(string type)
    {
        ColorBlock colorBlock = slider.colors;

        switch (type)
        {
            case "red":
                // Mudar cor do preenchimento, do botão e do slider no geral
                slider.fillRect.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                colorBlock.normalColor = new Color32(255, 0, 0, 255);
                break;
            case "green":
                slider.fillRect.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
                colorBlock.normalColor = new Color32(0, 255, 0, 255);
                break;
            case "yellow":
                slider.fillRect.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
                colorBlock.normalColor = new Color32(255, 255, 0, 255);
                break;
        }

        // Atualiza a cor de fundo do slider (backgroundColor)
        slider.targetGraphic.GetComponent<Image>().color = colorBlock.normalColor;
    }
    void DrenarConfianca()
    {
        slider.value += 0.4f;
    }

    void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}


