using UnityEngine;

[CreateAssetMenu(fileName = "NewSpeaker", menuName = "Data/New Speaker")]
[System.Serializable]
public class Speaker : ScriptableObject
{
    public Speaker(string speakerName, Color textColor)
    {
        this.speakerName = speakerName;
        this.textColor = textColor;
    }
    public string speakerName;
    public Color textColor;
}
