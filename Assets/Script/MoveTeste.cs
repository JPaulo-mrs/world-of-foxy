using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTeste : MonoBehaviour
{
    private float vel;
    public float jumpSpeed;
    public float moveSpeed;
    private Vector2 direcao;
    public Animator anim;
    private Rigidbody2D foxyRB;
    private bool pulo = false; 
    public float ymax;
    public float yatual;
    public bool Vdirecao;

    void Start()
    {
        foxyRB = GetComponent<Rigidbody2D>();
        vel = 3;
        direcao = Vector2.zero;
        yatual = 0;
        ymax = -500;
    }

    void Update()
    {
        InputPersonagem();
        Animacao(direcao);
        yatual = transform.position.y;
        if (pulo == false) 
        {
            ymax = -500;
            direcao = new Vector2(0,0);
        }
        if (yatual > ymax)
        {
            ymax = yatual;
        }
        if ((yatual == ymax) && pulo == true)
        {
            direcao = new Vector2(0,1);
        }
        if ((yatual != ymax) && pulo == true)
        {
            direcao = new Vector2(0,-1);
        }
        VerificaDirecao();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            pulo = false;
        }
    }
    void InputPersonagem()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            foxyRB.velocity = new Vector2(-moveSpeed, foxyRB.velocity.y);
            if (pulo == false)
            {
            direcao = new Vector2(-1,0);
            }
            Vdirecao = true;

        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            foxyRB.velocity = new Vector2(moveSpeed, foxyRB.velocity.y);
            if (pulo == false)
            {
            direcao = new Vector2(1,0);
            }
            Vdirecao = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && pulo == false)
        {
            foxyRB.velocity = new Vector2(foxyRB.velocity.x, jumpSpeed);
            pulo = true;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("atirando", true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            anim.SetBool("atirando", false);
        }
    }
    void Animacao(Vector2 dir)
    {
        anim.SetFloat("x", dir.x);
        anim.SetFloat("y", dir.y);
    }
    void VerificaDirecao()
    {
        if(Vdirecao)
        {
            transform.rotation = new Quaternion(0,180,0,0);
        }
        else
        {
            transform.rotation = new Quaternion(0,0,0,0);
        }
    }

}
