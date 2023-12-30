using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;
public class DialogController : MonoBehaviour
{

    public TextMeshProUGUI robberDialogText;
    public TextMeshProUGUI robberNameText;
    public TextMeshProUGUI victimDialogText;
    public TextMeshProUGUI victimNameText;

    private int sentenceIndex = 0;
    public StoryScene currentScene;
    private State state = State.IDLE;
    private Animator animator;
    private bool isHidden = false;

    private enum State
    {
        PLAYING, COMPLETED, IDLE
    }
    // Start is called before the first frame update

    void Start()
    {

    }


    public void PlayNextSentence()
    {

        if (sentenceIndex < currentScene.sentences.Count - 1)
        {
            sentenceIndex++;
            if (currentScene.sentences[sentenceIndex].speaker.speakerName == "Paul")
            {
                robberNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
                StartCoroutine(TypeText(currentScene.sentences[sentenceIndex].text, 0));
            }
            else
            {
                victimNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
                StartCoroutine(TypeText(currentScene.sentences[sentenceIndex].text, 1));
            }
        }
        else
        {
            sentenceIndex = 0;

            currentScene = (StoryScene)currentScene.nextScene;
            PlayScene(currentScene);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayScene(StoryScene scene)

    {


        if (scene == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }


    private IEnumerator TypeText(string text, int robberOrVictim)
    {

        string currentText = "";

        if (robberOrVictim == 0)
        {
            robberDialogText.text = "";
            robberNameText.text = "";
        }
        else
        {
            victimDialogText.text = "";
            victimNameText.text = "";
        }

        foreach (char letter in text.ToCharArray())
        {
            //se for a primeira letra, deixar maiuscula 

            state = State.PLAYING;
            currentText += letter;

            if (robberOrVictim == 0)
            {
                robberDialogText.text = currentText;
            }
            else
            {
                victimDialogText.text = currentText;
            }

            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(0.5f);
        state = State.COMPLETED;
    }






    public void ClearText()
    {
        robberDialogText.text = "";
        victimDialogText.text = "";
    }
    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    public int GetNextSentencesWords()
    {
        int qtdWords = 0;
        for (int i = sentenceIndex + 1; i < currentScene.sentences.Count; i++)
        {
            qtdWords += currentScene.sentences[i].text.Split(' ').Length;
        }
        return qtdWords;
    }
}
