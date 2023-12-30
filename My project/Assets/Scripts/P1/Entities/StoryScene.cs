using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
[System.Serializable]
public class StoryScene : GameScene
{
    public List<Sentence> sentences;

    public GameScene nextScene;

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Speaker speaker;

        public string type ; 

        public Sentence(string text, Speaker speaker, string type )
        {
            this.text = text;
            this.speaker = speaker;
            this.type = type;
            
        }
    }
}

public class GameScene : ScriptableObject { }
