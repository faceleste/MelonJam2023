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
        
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
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
        rb.velocity = movement.normalized * speed;
    }
}
