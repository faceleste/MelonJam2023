using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesconfiometroManager : MonoBehaviour
{

    public bool isVirado = false;
    public Slider slider;
    public GameObject backgroundOBJ;
    public GameObject boboObj;
    public GameObject saulObj;
    public GameObject faceOBJ;

    public PlayerMove player;
    [Header("Pessoas")]
    public Sprite sNormal;
    public Sprite sTenso;
    public Sprite sMedo;
    public Sprite boboNormal;
    public Sprite boboTenso;
    public Sprite boboMedo;
    public Sprite boboVirado;

    public Sprite lastBobo;
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
    public Animator animSlide;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DrenarConfianca", 0f, 1f);
        lastBobo = boboNormal;
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
                slider.value += 99;
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
        if(isVirado == false)
        {
            boboObj.GetComponent<Image>().sprite = boboMedo;
        }
        
        saulObj.GetComponent<Image>().sprite =  sMedo;
        lastBobo = boboMedo;

        faceOBJ.GetComponent<Image>().sprite = faceDesconfianca;
        boboscript.timeToView = 6;
        //mudar cor do slider e do fill do slider
        animSlide.SetBool("isTremendo", true);

    }

    void BaixaDesconfianca()
    {
        MudarCorSlider("green");
        backgroundOBJ.GetComponent<Image>().sprite = confiando;
        if(isVirado == false)
        {
            boboObj.GetComponent<Image>().sprite = boboNormal;
        }
        
        saulObj.GetComponent<Image>().sprite = sNormal;
        lastBobo = boboNormal;

        faceOBJ.GetComponent<Image>().sprite = faceConfianca;
        boboscript.timeToView = 20;
         animSlide.SetBool("isTremendo", false);
    }

    void MediaDesconfianca()
    {
        MudarCorSlider("yellow");
        boboscript.timeToView = 12;
        backgroundOBJ.GetComponent<Image>().sprite = desconfiado;

        if(isVirado == false)
        {
            boboObj.GetComponent<Image>().sprite = boboTenso;
        }
        
        saulObj.GetComponent<Image>().sprite = sTenso;
        lastBobo = boboTenso;

        faceOBJ.GetComponent<Image>().sprite = faceNeutral;
        animSlide.SetBool("isTremendo", false);

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

    public void changeSprite()
    {
        boboObj.GetComponent<Image>().sprite = lastBobo;
    }

    public void changeSpriteVirado()
    {
        boboObj.GetComponent<Image>().sprite = boboVirado;
    }
}


