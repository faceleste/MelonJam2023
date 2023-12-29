using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    public LayerMask objLayer;
    public bool isPlayerInvisible;
    public float rangeObj;

    public Animator anim;
    public SpriteRenderer sr;

    public float timeToEspirrar = 8;
    private float cooldownEspirro;
    public bool canWalk = true;
    public bool canStop = true;

    public bool canWin = false;
    // Start is called before the first frame update
    void Start()
    {
        cooldownEspirro = timeToEspirrar;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerInvisible = Physics2D.OverlapCircle(this.transform.position, rangeObj, objLayer);
        
        if(isPlayerInvisible)
        {
            sr.flipX = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("isEscondido", true);
            if(canStop)
            {
                 StartCoroutine(WaitStoped());
            }
           
            
        }
        else
        {
            canStop = true;
            anim.SetBool("isEscondido", false);
            
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        if(canWalk == true)
        {
            if(moveHorizontal > 0)
            {
                sr.flipX = true;
            }
            if(moveHorizontal < 0)
            {
                sr.flipX = false;
            }
            if(moveHorizontal != 0)
            {
                anim.SetBool("isWalking", true);
                cooldownEspirro = timeToEspirrar;
            }
        }
        
        else
        {
            anim.SetBool("isWalking", false);
            cooldownEspirro -= Time.deltaTime;
            if(cooldownEspirro <= 0)
            {
                anim.SetTrigger("isEspirrando");
                cooldownEspirro = timeToEspirrar;
            }
        }
        if(canWalk == true)
        {
            rb.velocity = movement.normalized * speed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        
    }

    IEnumerator WaitStoped()
    {
        canStop = false;
        canWalk = false;
        rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(1f);
        canWalk = true;
    }

    void OnTriggerEnter2D(Collision2D collision) 
    { 
        if (collision.gameObject.CompareTag("Porta")) 
        { 
            if(canWin == true)
            {
                 // VENCEU
            }
          
        } 
    } 

}
