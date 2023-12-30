using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
public class ChooseLabelController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public Desconfiometro desconfiometro;
    private StoryScene scene;
    private TextMeshProUGUI textMesh;
    private ChooseController controller;
    private ChooseScene.ChooseLabel label;

    void Awake()
    {


        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.color = defaultColor;
    }

    public float GetHeight()
    {
        return textMesh.rectTransform.sizeDelta.y * textMesh.rectTransform.localScale.y;
    }

    public float GetWidth()
    {
        return textMesh.rectTransform.sizeDelta.x * textMesh.rectTransform.localScale.x;
    }

    public void Setup(ChooseScene.ChooseLabel label, ChooseController controller, float y, float x)
    {
        scene = label.nextScene;
        textMesh.text = label.text;
        this.controller = controller;
        this.label = label;
        Vector3 position = textMesh.rectTransform.localPosition;
        position.y = y;
        position.x = x;
        textMesh.rectTransform.localPosition = position;
        // Adicione um identificador único ao objeto para referência futura
        gameObject.name = label.labelType;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Slider slider = GameObject.Find("Slider").GetComponent<Slider>();


        if (label.labelType == "good")
        {
            slider.value -= 20;
            Debug.Log("Teste");
        }

        if (label.labelType == "neutral")
        {
            slider.value += 10;
            List<string> neutralSentences = new List<string>();
            neutralSentences.Add("I don't know what to say.");
            neutralSentences.Add("...");
            neutralSentences.Add("?");
            neutralSentences.Add("Ok...?");

            int randomNumber = Random.Range(1, neutralSentences.Count);
            string randomQuote = neutralSentences[randomNumber];
            scene.sentences.Insert(0, new StoryScene.Sentence(randomQuote, new Speaker("Victim", Color.black), "created"));

        }
        if (label.labelType == "bad")
        {

            if (isGameOver(slider.value))
            {
                slider.value = 100;
            }
            slider.value += 20;
            List<string> badSentences = new List<string>();
            badSentences.Add("Go screw yourself.");
            badSentences.Add("Are you out of your mind? Why would you say that?");
            badSentences.Add("Get the fuck out of here...");
            badSentences.Add("Is that something you say?");
            badSentences.Add("Talking with you is just meaningless.");
            badSentences.Add("I wish I had spent my night doing something else");

            int randomNumber = Random.Range(1, badSentences.Count);

            string randomQuote = badSentences[randomNumber];
            scene.sentences.Insert(0, new StoryScene.Sentence(randomQuote, new Speaker("Victim", Color.black), "created"));
            Debug.Log("Teste2");
        }

        controller.PerformChoose(scene);
    }


    public bool isGameOver(float value)
    {

        return ((int)100 - value) == (int)value;


    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        textMesh.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textMesh.color = defaultColor;
    }
}
