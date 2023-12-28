using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoboScript : MonoBehaviour
{
    public float timeToView = 10;
    private float cooldownView;
    public bool playerSeen;
    public PlayerMove player;
    // Start is called before the first frame update
    void Start()
    {
        cooldownView = timeToView;
    }

    // Update is called once per frame
    void Update()
    {
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
}
