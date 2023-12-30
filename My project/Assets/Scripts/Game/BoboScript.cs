using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoboScript : MonoBehaviour
{
    public float timeToView = 10;
    private float cooldownView;
    public bool playerSeen;
    public PlayerMove player;

    public LayerMask playerLayer;
    public bool isViewPlayer = false;
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
    public GameObject itensFurto;
    public DialogManager dialogo;

    public bool seeLong;
    public float rangeSeeLong;
    public bool seeMedium;
    public float rangeSeeMedium;
    public bool seeNext;
    
    public GameObject simboloExclamacao;
    public GameObject simboloExclamacao2;
    public float rangeSeeNext;

    public DesconfiometroManager desconfiometro;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTakeItem = timeTakeItem;
        cooldownView = timeToView;
    }

    // Update is called once per frame
    void Update()
    {
        if (seeMedium == false)
        {
            seeLong = Physics2D.OverlapCircle(this.transform.position, rangeSeeLong, playerLayer);
        }
        if (seeNext == false)
        {
            seeMedium = Physics2D.OverlapCircle(this.transform.position, rangeSeeMedium, playerLayer);
        }
        seeNext = Physics2D.OverlapCircle(this.transform.position, rangeSeeNext, playerLayer);

        isPlayerVisible = Physics2D.OverlapCircle(this.transform.position, rangeObj, playerLayer);
        cooldownView -= Time.deltaTime;

        if (seeLong == true)
        {
            if(cooldownView <= 2.5f && cooldownView > 1.5f)
            {
                simboloExclamacao.SetActive(true);
                simboloExclamacao2.SetActive(true);
                //desconfiometro.boboObj.GetComponent<Image>().sprite = desconfiometro.boboVirado; 
            }
            else
            {
                //simboloExclamacao.SetActive(false);
                //simboloExclamacao2.SetActive(false);
                //desconfiometro.boboObj.GetComponent<Image>().sprite = desconfiometro.lastBobo; 
            }
            if (cooldownView <= 1.5f && cooldownView > 0)
            {
                 desconfiometro.isVirado = true;
                simboloExclamacao2.SetActive(false);
                desconfiometro.changeSpriteVirado();
                player.canWalk = false;
                camera.SmoothFactor = 4;
                camera.player = this.transform;
                if (cooldownView <= 1f)
                {
                    srBobo.sprite = boboAssustado;
                    srCharmoso.sprite = charmosoAssustado;
                }
            }
            else if (cooldownView <= 0 && cooldownView > -1)
            {
                camera.player = camera.playerAgain;
                player.canWalk = true;
            }

            if (cooldownView <= -1.5f)
            {
                
                simboloExclamacao.SetActive(false);
                desconfiometro.isVirado = false;
                srBobo.sprite = boboNormal;
                srCharmoso.sprite = charmosoNormal;
                cooldownView = timeToView;
                camera.SmoothFactor = 2;
                Debug.Log("Perdeu bobo");
                isViewPlayer = true;
                desconfiometro.changeSprite();
                //GAMEOVER
            }
        }
        else
        {
            cooldownView = timeToView;
        }

    }

    void FixedUpdate()
    {
        if (isPlayerVisible)
        {
            barras.SetActive(true);
            if (Input.GetButton("Fire3"))
            {
                if (player.canWin == false)
                {
                    cooldownTakeItem -= Time.deltaTime;
                    barraCircular.AtualizarBarra(cooldownTakeItem);

                    if (cooldownTakeItem <= 0)
                    {
                        // PEGA ITEM
                        player.canWin = true;
                        dialogo.falaPlayer = "Peguei xo vazar vazar!!";
                        dialogo.VerificaMsg();
                        itensFurto.SetActive(false);
                    }
                }
                else
                {
                    dialogo.falaPlayer = "Eu já peguei isso, o que eu to fazendo aqui?";
                    dialogo.VerificaMsg();
                }
            }
            else
            {
                if (cooldownTakeItem <= timeTakeItem)
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


    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
        Gizmos.DrawSphere(transform.position, rangeSeeLong);
        Gizmos.DrawSphere(transform.position, rangeSeeMedium);
        Gizmos.DrawSphere(transform.position, rangeSeeNext);
    }
}
