using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoboScript : MonoBehaviour
{
    public float timeToView = 10;
    private float cooldownView;
    public bool playerSeen;
    public PlayerMove player;

    public LayerMask playerLayer;
    public bool isPlayerVisible;
    public float rangeObj;

    public float timeTakeItem = 3;
    public float cooldownTakeItem;
    [SerializeField] BarraCircular barraCircular;
    public GameObject barras;

    public SpriteRenderer srBobo;
    public Sprite boboNormal;
    public Sprite boboAssustado;

    public SpriteRenderer srCharmoso;
    public Sprite charmosoNormal;
    public Sprite charmosoAssustado;
    public Cam camera;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTakeItem = timeTakeItem;
        cooldownView = timeToView;
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerVisible = Physics2D.OverlapCircle(this.transform.position, rangeObj, playerLayer);
        cooldownView -= Time.deltaTime;
        if(cooldownView <= 1.5f && cooldownView > 0)
        {
            camera.SmoothFactor = 4;
            camera.player = this.transform;
            if(cooldownView <= 1f)
            {
                srBobo.sprite = boboAssustado;
                srCharmoso.sprite = charmosoAssustado;
            }
        }
        else if(cooldownView <= 0 && cooldownView > -1)
        {
            camera.player = camera.playerAgain;
        }
        if(cooldownView <= -2.5f)
        {
            srBobo.sprite = boboNormal;
            srCharmoso.sprite = charmosoNormal;
            cooldownView = timeToView; 
            camera.SmoothFactor = 2;
            Debug.Log("Perdeu bobo");
            //GAMEOVER
        }
    }

    void FixedUpdate()
    {
        if(isPlayerVisible)
        {
            barras.SetActive(true);
            if(Input.GetButton("Fire3"))
            {
                cooldownTakeItem -= Time.deltaTime;
                barraCircular.AtualizarBarra(cooldownTakeItem);

                if(cooldownTakeItem <= 0)
                {
                    // PEGA ITEM
                }
            }
            else
            {
                if(cooldownTakeItem <= timeTakeItem)
                {
                    cooldownTakeItem += Time.deltaTime;
                    barraCircular.AtualizarBarra(cooldownTakeItem);
                }
            }
        }
        else
        {
            barras.SetActive(false);
            cooldownTakeItem = timeTakeItem;
            barraCircular.AtualizarBarra(cooldownTakeItem);
        }
        
    }
}
