using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameScene currentScene;
    public DialogController dialog;
    public ChooseController chooseController;

    private State state = State.IDLE;
    float tempoDecorrido = 0f;
    float intervalo = 0f;

    private enum State
    {
        IDLE, ANIMATE, CHOOSE
    }

    void Start()
    {
        if (currentScene is StoryScene)
        {
            StoryScene storyScene = currentScene as StoryScene;
            dialog.PlayScene(storyScene);
        }
    }

    void Update()
    {

        tempoDecorrido += Time.deltaTime;


        if (tempoDecorrido >= intervalo)
        {

            tempoDecorrido = 0f;

            if (state == State.IDLE && dialog.IsCompleted())
            {
                if (dialog.IsLastSentence())
                {
                    PlayScene((currentScene as StoryScene).nextScene);
                }
                else
                {
                    int qtdWords = dialog.GetNextSentencesWords();
                    intervalo = qtdWords * 0.048f;
                    Debug.Log("Quantidade de palavras: " + qtdWords + " Intervalo: " + intervalo);
                    dialog.PlayNextSentence();
                }
            }
        }
    }

    public void PlayScene(GameScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(GameScene scene)
    {
        state = State.ANIMATE;
        currentScene = scene;

        yield return new WaitForSeconds(1f);
        if (scene is StoryScene)
        {
            chooseController.DestroyLabels();
            StoryScene storyScene = scene as StoryScene;
            yield return new WaitForSeconds(1f);
            dialog.ClearText();

            yield return new WaitForSeconds(1f);
            dialog.PlayScene(storyScene);
            state = State.IDLE;
        }
        else if (scene is ChooseScene)
        {
            state = State.CHOOSE;
            chooseController.SetupChoose(scene as ChooseScene);
        }

       
        if (scene is StoryScene)
        {
            StoryScene storySceneInstance = scene as StoryScene;  
            if (storySceneInstance.sentences[0].type == "created")
            {
                storySceneInstance.sentences.RemoveAt(0);
            }
        }
    }
}
