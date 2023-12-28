using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Speaker", menuName = "Data/Speaker", order = 1)]
[System.Serializable]
public class Speaker : ScriptableObject
{

    public string speakerName;
    public Color colorSpeaker; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
