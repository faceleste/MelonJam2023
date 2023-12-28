using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public float typeDelay = 0.05f;
    public TextMeshProUGUI textObject;
    public string falaPlayer;
    public bool canShowDialog = false;
    public bool isShowing = false;
    public bool canShowAgain;
    public GameObject caixaDialogo;

    public AudioClip[] audioClips;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void VerificaMsg()
    {

        StartCoroutine(TypeText());
        
    }

    public void playAudioRandom()
    {
        //audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        //audioSource.Play();
    }

    public IEnumerator TypeText()
    {
        //playAudioRandom();
        if (isShowing == false)
        {
            playAudioRandom();
            caixaDialogo.SetActive(true);
            canShowDialog = false;
            isShowing = true;
            textObject.text = falaPlayer;
            textObject.maxVisibleCharacters = 0;
            for (int i = 0; i <= textObject.text.Length; i++)
            {
                textObject.maxVisibleCharacters = i;
                yield return new WaitForSeconds(typeDelay);
            }
            yield return new WaitForSeconds(1.5f);
            caixaDialogo.SetActive(false);
            isShowing = false;
        }
        
    }

}
