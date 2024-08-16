using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private Rigidbody2D inimigoRB;
    public float moveSpeed;
    public Animator anim;
    public bool Y;
    void Start()
    {
        inimigoRB = GetComponent<Rigidbody2D>();
        if(Y)
        {
            inimigoRB.velocity = new Vector2(inimigoRB.velocity.x, moveSpeed);
        }
        else
        {
            inimigoRB.velocity = new Vector2(-moveSpeed, inimigoRB.velocity.y);
        }
    }

    
    void Update()
    {
        
    }
    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Limite E"))
        {
            inimigoRB.velocity = new Vector2(moveSpeed, inimigoRB.velocity.y);
            transform.rotation = new Quaternion(0,180,0,0);
        }
        if (collision.gameObject.CompareTag("Limite D"))
        {
            inimigoRB.velocity = new Vector2(-moveSpeed, inimigoRB.velocity.y);
            transform.rotation = new Quaternion(0,0,0,0);
        }
        if (collision.gameObject.CompareTag("Limite C"))
        {
            inimigoRB.velocity = new Vector2(inimigoRB.velocity.x, -moveSpeed);
            transform.rotation = new Quaternion(0,0,0,0);
        }
        if (collision.gameObject.CompareTag("Limite B"))
        {
            inimigoRB.velocity = new Vector2(inimigoRB.velocity.x, moveSpeed);
            transform.rotation = new Quaternion(0,0,0,0);
        }
        if (collision.gameObject.CompareTag("Pisada"))
        {
            inimigoRB.velocity = new Vector2(0, 0);
            anim.Play("FX");
            yield return new WaitForSeconds(0.3f); 
            Destroy(gameObject);
        }
    }

}
