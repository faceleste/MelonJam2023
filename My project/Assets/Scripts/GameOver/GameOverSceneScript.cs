using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneScript : MonoBehaviour
{
    public Animator anim;
    public bool canEnd = true;
    public bool isMenuInicial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMenuInicial == false)
        {
            if (Input.anyKey && canEnd == true)
            {
                StartCoroutine(WaitToChangeScene()); 
            }
        }
        else
        {

        }
        
    }

    public void IniciarJogo()
    {
        StartCoroutine(WaitToStartGame()); 
    }

    IEnumerator WaitToStartGame()
    {
        canEnd = false;
        anim.SetTrigger("isFechando");
        yield return new WaitForSeconds(1.1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    IEnumerator WaitToChangeScene()
    {
        canEnd = false;
        anim.SetTrigger("isFechando");
        yield return new WaitForSeconds(1.1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
