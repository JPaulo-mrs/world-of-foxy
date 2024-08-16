using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public static Boss instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public Rigidbody2D bossRB;
    public bool vira;
    public float moveSpeed;
    public Animator anim;
    public int vida;
    
    public Image[] core;
    [SerializeField]
    private CircleCollider2D ataque1;
    [SerializeField]
    private BoxCollider2D ataque2;
    [SerializeField]
    private BoxCollider2D ataque3;
    [SerializeField]
    private BoxCollider2D corpo;
    public bool ataque;
    public bool morte;
    public int modo;
    public string nomeScene;


    void Start()
    {
        vida = 10;
        ataque = false;
        ataque1.enabled = false;
        ataque2.enabled = false;
        ataque3.enabled = false;
        anim.Play("Boss_andando");
        bossRB.velocity = new Vector2(-moveSpeed, bossRB.velocity.y);
        StartCoroutine(Movimento());
        morte = false;
    }

    // Update is called once per frame
    void Update()
    {
        CalculoV();
        if (ataque)
        {
            switch (modo)
            {
                case 1:
                    ataque1.enabled = true;
                    ataque2.enabled = false;
                    ataque3.enabled = false;
                    anim.Play("Boss_A1"); 
                    break;
                 case 2:
                    ataque1.enabled = false;
                    ataque2.enabled = true;
                    ataque3.enabled = false; 
                    anim.Play("Boss_A2"); 
                    break;
                 case 3:
                    ataque1.enabled = false;
                    ataque2.enabled = false;
                    ataque3.enabled = true; 
                    anim.Play("Boss_A3"); 
                    break;
                default:
                    ataque1.enabled = false;
                    ataque2.enabled = false;
                    ataque3.enabled = false; 
                    break;
            }
        }
        else
        {
            AtaqueEnab();
        }
    }
    public void AtaqueEnab()
    {
        ataque1.enabled = false;
        ataque2.enabled = false;
        ataque3.enabled = false;
    }
    void CalculoV()
    {
        switch (vida)
        {
            case 0:
                core[0].color = new Color (0,0,0,0);
                core[1].color = new Color (0,0,0,0);
                core[2].color = new Color (0,0,0,0);
                core[3].color = new Color (0,0,0,0);
                core[4].color = new Color (0,0,0,0);
                core[5].color = new Color (0,0,0,0);
                core[6].color = new Color (0,0,0,0);
                core[7].color = new Color (0,0,0,0);
                core[8].color = new Color (0,0,0,0);
                core[9].color = new Color (0,0,0,0);
                core[10].color = new Color (1,1,1,1);
                core[11].color = new Color (1,1,1,1);
                core[12].color = new Color (1,1,1,1);
                core[13].color = new Color (1,1,1,1);
                core[14].color = new Color (1,1,1,1);
                core[15].color = new Color (1,1,1,1);
                core[16].color = new Color (1,1,1,1);
                core[17].color = new Color (1,1,1,1);
                core[18].color = new Color (1,1,1,1);
                core[19].color = new Color (1,1,1,1);
                core[20].color = new Color (1,1,1,1);
                anim.Play("Boss_morte");
                StartCoroutine(morto());
                morte = true;
                break;
            case 1:
                core[0].color = new Color (1,1,1,1);
                core[1].color = new Color (0,0,0,0);
                core[2].color = new Color (0,0,0,0);
                core[3].color = new Color (0,0,0,0);
                core[4].color = new Color (0,0,0,0);
                core[5].color = new Color (0,0,0,0);
                core[6].color = new Color (0,0,0,0);
                core[7].color = new Color (0,0,0,0);
                core[8].color = new Color (0,0,0,0);
                core[9].color = new Color (0,0,0,0);
                core[10].color = new Color (0,0,0,0);
                core[11].color = new Color (1,1,1,1);
                core[12].color = new Color (1,1,1,1);
                core[13].color = new Color (1,1,1,1);
                core[14].color = new Color (1,1,1,1);
                core[15].color = new Color (1,1,1,1);
                core[16].color = new Color (1,1,1,1);
                core[17].color = new Color (1,1,1,1);
                core[18].color = new Color (1,1,1,1);
                core[19].color = new Color (1,1,1,1);
                core[20].color = new Color (1,1,1,1);
                break;
            case 2:
                core[0].color = new Color (1,1,1,1);
                core[1].color = new Color (1,1,1,1);
                core[2].color = new Color (0,0,0,0);
                core[3].color = new Color (0,0,0,0);
                core[4].color = new Color (0,0,0,0);
                core[5].color = new Color (0,0,0,0);
                core[6].color = new Color (0,0,0,0);
                core[7].color = new Color (0,0,0,0);
                core[8].color = new Color (0,0,0,0);
                core[9].color = new Color (0,0,0,0);
                core[10].color = new Color (0,0,0,0);
                core[11].color = new Color (0,0,0,0);
                core[12].color = new Color (1,1,1,1);
                core[13].color = new Color (1,1,1,1);
                core[14].color = new Color (1,1,1,1);
                core[15].color = new Color (1,1,1,1);
                core[16].color = new Color (1,1,1,1);
                core[17].color = new Color (1,1,1,1);
                core[18].color = new Color (1,1,1,1);
                core[19].color = new Color (1,1,1,1);
                core[20].color = new Color (1,1,1,1);
                break;
            case 3:
                core[0].color = new Color (1,1,1,1);
                core[1].color = new Color (1,1,1,1);
                core[2].color = new Color (1,1,1,1);
                core[3].color = new Color (0,0,0,0);
                core[4].color = new Color (0,0,0,0);
                core[5].color = new Color (0,0,0,0);
                core[6].color = new Color (0,0,0,0);
                core[7].color = new Color (0,0,0,0);
                core[8].color = new Color (0,0,0,0);
                core[9].color = new Color (0,0,0,0);
                core[10].color = new Color (0,0,0,0);
                core[11].color = new Color (0,0,0,0);
                core[12].color = new Color (0,0,0,0);
                core[13].color = new Color (1,1,1,1);
                core[14].color = new Color (1,1,1,1);
                core[15].color = new Color (1,1,1,1);
                core[16].color = new Color (1,1,1,1);
                core[17].color = new Color (1,1,1,1);
                core[18].color = new Color (1,1,1,1);
                core[19].color = new Color (1,1,1,1);
                core[20].color = new Color (1,1,1,1);
                modo = 3;
                moveSpeed = 10;
                break;
            case 4:
                core[0].color = new Color (1,1,1,1);
                core[1].color = new Color (1,1,1,1);
                core[2].color = new Color (1,1,1,1);
                core[3].color = new Color (1,1,1,1);
                core[4].color = new Color (0,0,0,0);
                core[5].color = new Color (0,0,0,0);
                core[6].color = new Color (0,0,0,0);
                core[7].color = new Color (0,0,0,0);
                core[8].color = new Color (0,0,0,0);
                core[9].color = new Color (0,0,0,0);
                core[10].color = new Color (0,0,0,0);
                core[11].color = new Color (0,0,0,0);
                core[12].color = new Color (0,0,0,0);
                core[13].color = new Color (0,0,0,0);
                core[14].color = new Color (1,1,1,1);
                core[15].color = new Color (1,1,1,1);
                core[16].color = new Color (1,1,1,1);
                core[17].color = new Color (1,1,1,1);
                core[18].color = new Color (1,1,1,1);
                core[19].color = new Color (1,1,1,1);
                core[20].color = new Color (1,1,1,1);
                break;
            case 5:
                core[0].color = new Color (1,1,1,1);
                core[1].color = new Color (1,1,1,1);
                core[2].color = new Color (1,1,1,1);
                core[3].color = new Color (1,1,1,1);
                core[4].color = new Color (1,1,1,1);
                core[5].color = new Color (0,0,0,0);
                core[6].color = new Color (0,0,0,0);
                core[7].color = new Color (0,0,0,0);
                core[8].color = new Color (0,0,0,0);
                core[9].color = new Color (0,0,0,0);
                core[10].color = new Color (0,0,0,0);
                core[11].color = new Color (0,0,0,0);
                core[12].color = new Color (0,0,0,0);
                core[13].color = new Color (0,0,0,0);
                core[14].color = new Color (0,0,0,0);
                core[15].color = new Color (1,1,1,1);
                core[16].color = new Color (1,1,1,1);
                core[17].color = new Color (1,1,1,1);
                core[18].color = new Color (1,1,1,1);
                core[19].color = new Color (1,1,1,1);
                core[20].color = new Color (1,1,1,1);
                break;
            case 6:
                core[0].color = new Color (1,1,1,1);
                core[1].color = new Color (1,1,1,1);
                core[2].color = new Color (1,1,1,1);
                core[3].color = new Color (1,1,1,1);
                core[4].color = new Color (1,1,1,1);
                core[5].color = new Color (1,1,1,1);
                core[6].color = new Color (0,0,0,0);
                core[7].color = new Color (0,0,0,0);
                core[8].color = new Color (0,0,0,0);
                core[9].color = new Color (0,0,0,0);
                core[10].color = new Color (0,0,0,0);
                core[11].color = new Color (0,0,0,0);
                core[12].color = new Color (0,0,0,0);
                core[13].color = new Color (0,0,0,0);
                core[14].color = new Color (0,0,0,0);
                core[15].color = new Color (0,0,0,0);
                core[16].color = new Color (1,1,1,1);
                core[17].color = new Color (1,1,1,1);
                core[18].color = new Color (1,1,1,1);
                core[19].color = new Color (1,1,1,1);
                core[20].color = new Color (1,1,1,1);
                modo = 2;
                moveSpeed = 7;
                break;
            case 7:
                core[0].color = new Color (1,1,1,1);
                core[1].color = new Color (1,1,1,1);
                core[2].color = new Color (1,1,1,1);
                core[3].color = new Color (1,1,1,1);
                core[4].color = new Color (1,1,1,1);
                core[5].color = new Color (1,1,1,1);
                core[6].color = new Color (1,1,1,1);
                core[7].color = new Color (0,0,0,0);
                core[8].color = new Color (0,0,0,0);
                core[9].color = new Color (0,0,0,0);
                core[10].color = new Color (0,0,0,0);
                core[11].color = new Color (0,0,0,0);
                core[12].color = new Color (0,0,0,0);
                core[13].color = new Color (0,0,0,0);
                core[14].color = new Color (0,0,0,0);
                core[15].color = new Color (0,0,0,0);
                core[16].color = new Color (0,0,0,0);
                core[17].color = new Color (1,1,1,1);
                core[18].color = new Color (1,1,1,1);
                core[19].color = new Color (1,1,1,1);
                core[20].color = new Color (1,1,1,1);
                break;
            case 8:
                core[0].color = new Color (1,1,1,1);
                core[1].color = new Color (1,1,1,1);
                core[2].color = new Color (1,1,1,1);
                core[3].color = new Color (1,1,1,1);
                core[4].color = new Color (1,1,1,1);
                core[5].color = new Color (1,1,1,1);
                core[6].color = new Color (1,1,1,1);
                core[7].color = new Color (1,1,1,1);
                core[8].color = new Color (0,0,0,0);
                core[9].color = new Color (0,0,0,0);
                core[10].color = new Color (0,0,0,0);
                core[11].color = new Color (0,0,0,0);
                core[12].color = new Color (0,0,0,0);
                core[13].color = new Color (0,0,0,0);
                core[14].color = new Color (0,0,0,0);
                core[15].color = new Color (0,0,0,0);
                core[16].color = new Color (0,0,0,0);
                core[17].color = new Color (0,0,0,0);
                core[18].color = new Color (1,1,1,1);
                core[19].color = new Color (1,1,1,1);
                core[20].color = new Color (1,1,1,1);
                break;
            case 9:
                core[0].color = new Color (1,1,1,1);
                core[1].color = new Color (1,1,1,1);
                core[2].color = new Color (1,1,1,1);
                core[3].color = new Color (1,1,1,1);
                core[4].color = new Color (1,1,1,1);
                core[5].color = new Color (1,1,1,1);
                core[6].color = new Color (1,1,1,1);
                core[7].color = new Color (1,1,1,1);
                core[8].color = new Color (1,1,1,1);
                core[9].color = new Color (0,0,0,0);
                core[10].color = new Color (0,0,0,0);
                core[11].color = new Color (0,0,0,0);
                core[12].color = new Color (0,0,0,0);
                core[13].color = new Color (0,0,0,0);
                core[14].color = new Color (0,0,0,0);
                core[15].color = new Color (0,0,0,0);
                core[16].color = new Color (0,0,0,0);
                core[17].color = new Color (0,0,0,0);
                core[18].color = new Color (0,0,0,0);
                core[19].color = new Color (1,1,1,1);
                core[20].color = new Color (1,1,1,1);
                break;
            case 10:
                core[0].color = new Color (1,1,1,1);
                core[1].color = new Color (1,1,1,1);
                core[2].color = new Color (1,1,1,1);
                core[3].color = new Color (1,1,1,1);
                core[4].color = new Color (1,1,1,1);
                core[5].color = new Color (1,1,1,1);
                core[6].color = new Color (1,1,1,1);
                core[7].color = new Color (1,1,1,1);
                core[8].color = new Color (1,1,1,1);
                core[9].color = new Color (1,1,1,1);
                core[10].color = new Color (0,0,0,0);
                core[11].color = new Color (0,0,0,0);
                core[12].color = new Color (0,0,0,0);
                core[13].color = new Color (0,0,0,0);
                core[14].color = new Color (0,0,0,0);
                core[15].color = new Color (0,0,0,0);
                core[16].color = new Color (0,0,0,0);
                core[17].color = new Color (0,0,0,0);
                core[18].color = new Color (0,0,0,0);
                core[19].color = new Color (0,0,0,0);
                core[20].color = new Color (1,1,1,1);
                modo = 1;
                moveSpeed = 5;
                break;
            default:
                core[0].color = new Color (0,0,0,0);
                core[1].color = new Color (0,0,0,0);
                core[2].color = new Color (0,0,0,0);
                core[3].color = new Color (0,0,0,0);
                core[4].color = new Color (0,0,0,0);
                core[5].color = new Color (0,0,0,0);
                core[6].color = new Color (0,0,0,0);
                core[7].color = new Color (0,0,0,0);
                core[8].color = new Color (0,0,0,0);
                core[9].color = new Color (0,0,0,0);
                core[10].color = new Color (0,0,0,0);
                core[11].color = new Color (0,0,0,0);
                core[12].color = new Color (0,0,0,0);
                core[13].color = new Color (0,0,0,0);
                core[14].color = new Color (0,0,0,0);
                core[15].color = new Color (0,0,0,0);
                core[16].color = new Color (0,0,0,0);
                core[17].color = new Color (0,0,0,0);
                core[18].color = new Color (0,0,0,0);
                core[19].color = new Color (0,0,0,0);
                core[20].color = new Color (0,0,0,0);
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Limite E"))
        {
            anim.Play("Boss_andando");
            bossRB.velocity = new Vector2(moveSpeed, bossRB.velocity.y);
            transform.rotation = new Quaternion(0,180,0,0);
            vira = true;
            StartCoroutine(Movimento());
        }
        if (collision.gameObject.CompareTag("Limite D"))
        {
            bossRB.velocity = new Vector2(-moveSpeed, bossRB.velocity.y);
            transform.rotation = new Quaternion(0,0,0,0);
            vira = false;
            StartCoroutine(Movimento());
        }
    }
    IEnumerator Movimento()
    {
        bossRB.velocity = new Vector2(bossRB.velocity.x, bossRB.velocity.y);
        yield return new WaitForSeconds (3);
        bossRB.velocity = new Vector2(0, bossRB.velocity.y);
        ataque = true;
        yield return new WaitForSeconds (1f);
        ataque = false;
        if(morte == false)
        {
            if (vira)
            {
                bossRB.velocity = new Vector2(moveSpeed, bossRB.velocity.y);
                anim.Play("Boss_andando");
            }
            else
            {
                bossRB.velocity = new Vector2(-moveSpeed, bossRB.velocity.y);
                anim.Play("Boss_andando");
            }
        }
        else
        {
            bossRB.velocity = new Vector2(0, bossRB.velocity.y);
        }
    }
    IEnumerator morto()
    {
        bossRB.velocity = new Vector2(0, bossRB.velocity.y);
        corpo.enabled = false;
        ataque = false;
        yield return new WaitForSeconds (2f);
        SceneManager.LoadScene("Fim");
    }
}
