using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{

    public GameObject canvas;
    public GameObject audioPage;
    public GameObject videoPage;
    // Start is called before the first frame update
    void Start()
    {
        videoPage.SetActive(true);
        audioPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }


    public void AbrirAudio()
    {
        Debug.Log("Abrindo audio ... ");
        audioPage.SetActive(true);
        videoPage.SetActive(false);
    }

    public void AbrirVideo()
    {
        Debug.Log("Abrindo video ... ");
        audioPage.SetActive(false);
        videoPage.SetActive(true);
    }

    public void ChangeVolume(float volume)
    {
        Debug.Log("Volume: " + volume);
        AudioListener.volume = volume;
    }

    public void ChangeToFullScreen(bool isFullScreen)
    {
        Debug.Log("FullScreen: " + isFullScreen);
        Screen.fullScreen = isFullScreen;
    }

    public void ChangeResolution(int index)
    {
        Debug.Log("Resolution: " + index);
        switch (index)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1024, 768, Screen.fullScreen);
                break;
            case 3:
                Screen.SetResolution(800, 600, Screen.fullScreen);
                break;
            default:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
        }
    }
    
    public void FecharOpcoes()
    {
        canvas.SetActive(false);
    }
}
