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
    private State state = State.COMPLETED;
    private Animator animator;
    private bool isHidden = false;

    private enum State
    {
        PLAYING, COMPLETED
    }
    // Start is called before the first frame update

    void Start()
    {

    }


    public void PlayChoose(ChooseScene scene)
    {

    }
    public void PlayNextSentence()
    {

        //ficar trocando os dialogos entre os personagens; tanto o robber quanto a vitima
        if (sentenceIndex < currentScene.sentences.Count - 1)
        {
            sentenceIndex++;
            if (currentScene.sentences[sentenceIndex].speaker.speakerName == "Robber")
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

        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }


    private IEnumerator TypeText(string text, int robberOrVictim)
    {
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
            if (robberOrVictim == 0)
            {
                robberDialogText.text += letter;
            }
            else
            {
                victimDialogText.text += letter;
            }
            yield return new WaitForSeconds(0.05f);
        }

    }



    public void Hide()
    {
        if (!isHidden)
        {
            animator.SetTrigger("Hide");
            isHidden = true;
        }
    }

    public void Show()
    {
        animator.SetTrigger("Show");
        isHidden = false;
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
}
