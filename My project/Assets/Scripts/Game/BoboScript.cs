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
        if(cooldownView <= 0)
        {
            if(player.isPlayerInvisible != true)
            {
                //GAMEOVER
            }
            else
            {
                cooldownView = timeToView; 
            }
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
