using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    public static UI instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public int C, D, U;
    public int life;
    public int gold;
    public int VI;
    [SerializeField]
    private Image[] GC;
    [SerializeField]
    private Image[] GD;
    [SerializeField]
    private Image[] GU;
    [SerializeField]
    private Image[] Vida;
    public string nomeScene;
    [SerializeField]
    private GameObject audioPF;
    [SerializeField]
    private AudioSource audioIN;
    [SerializeField]
    private GameObject audioBS; 
    [SerializeField]
    private Image[] Contador;
    [SerializeField]
    private Animator black;
    [SerializeField]
    private Animator X;
    [SerializeField]
    private Animator Face;
    [SerializeField]
    private Animator Check;
    [SerializeField]
    private Animator CheckB;
    [SerializeField]
    private Animator ParedeL;
    [SerializeField]
    private Animator ParedeR;
    public bool exibe;
    public bool check;
    public bool checkB;
    public bool Compra;
    public bool trocaM;
    private Rigidbody2D foxyRB;
    private Vector3 respawn;


    void Start()
    {
        Physics2D.IgnoreLayerCollision(8,9);
        
        StartCoroutine(Ini());
        gold = 0;
        life = 3;
        VI = 5;
        foxyRB = GetComponent<Rigidbody2D>();
        respawn = new Vector3(-6,2,0);
        check = true;
        checkB = true;
        Compra = true;
        
    }

    void Update()
    {
        CalculoG();
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            life -= 1;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            life += 1;
        }
        if (life >= 3)
        {
            life = 3; 
        }
        if (life <= 0)
        {
            life = 0; 
        }
        CalculoV();
        CalculoL();
    }
    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            Destroy(collision.gameObject);
            Instantiate(audioPF, transform.position, Quaternion.identity);
            gold += 5;
        }
        if (collision.gameObject.CompareTag("Check"))
        {
            if(check)
            {
                respawn = collision.transform.position;
                Check.Play("checkpoint");
                check = false;
            }
            
        }
        if (collision.gameObject.CompareTag("CheckB"))
        {
            if(checkB)
            {
                respawn = collision.transform.position;
                audioIN.enabled = false; 
                Instantiate(audioBS, transform.position, Quaternion.identity);
                CheckB.Play("checkpoint");
                ParedeL.Play("Fechando");
                ParedeR.Play("ParedeR");
                checkB = false;
            }
            
        }
        yield return new  WaitForSeconds(0.5f);
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            life -= 1;
        }
        if (collision.gameObject.CompareTag("Destruir"))
        {
            life = 0;
            transform.position = respawn;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            life -= 1;
        }
    }
    IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Vendedor") && gold >= 100 && Input.GetKeyDown(KeyCode.K) && Compra == true)
        {
            VI += 1;
            gold -= 100;
            Compra = false;
            yield return new  WaitForSeconds(0.5f);
            Compra = true;
        }
    }
    void CalculoG()
    {
        C = gold/100;
        D = (gold - (C * 100))/10;
        U = (gold - (C * 100) - (D * 10));
        for (int i= 0; i<= 9; i++)
        {
            GC[i].color = new Color(0,0,0,0);
        }
        for (int i= 0; i<= 9; i++)
        {
            GD[i].color = new Color(0,0,0,0);
        }
        for (int i= 0; i<= 9; i++)
        {
            GU[i].color = new Color(0,0,0,0);
        }
        GC[C].color = new Color (1,1,1,1);
        GD[D].color = new Color (1,1,1,1);
        GU[U].color = new Color (1,1,1,1);
    }

    void CalculoV()
    {
        switch (life)
        {
            case 0:
                transform.position = respawn;
                Vida[0].color = new Color (1,1,1,1);
                Vida[1].color = new Color (1,1,1,1);
                Vida[2].color = new Color (1,1,1,1);
                Vida[3].color = new Color (0,0,0,0);
                Vida[4].color = new Color (0,0,0,0);
                Vida[5].color = new Color (0,0,0,0);
                VI -= 1;
                transform.position = respawn;
                black.Play("vazio");
                X.Play("vazio");
                Face.Play("vazio");
                StartCoroutine(Num());
                life = 3;
                break;
            case 1:
                Vida[0].color = new Color (0,0,0,0);
                Vida[1].color = new Color (1,1,1,1);
                Vida[2].color = new Color (1,1,1,1);
                Vida[3].color = new Color (1,1,1,1);
                Vida[4].color = new Color (0,0,0,0);
                Vida[5].color = new Color (0,0,0,0);
                break;
            case 2:
                Vida[0].color = new Color (0,0,0,0);
                Vida[1].color = new Color (0,0,0,0);
                Vida[2].color = new Color (1,1,1,1);
                Vida[3].color = new Color (1,1,1,1);
                Vida[4].color = new Color (1,1,1,1);
                Vida[5].color = new Color (0,0,0,0);
                break;
            case 3:
                Vida[0].color = new Color (0,0,0,0);
                Vida[1].color = new Color (0,0,0,0);
                Vida[2].color = new Color (0,0,0,0);
                Vida[3].color = new Color (1,1,1,1);
                Vida[4].color = new Color (1,1,1,1);
                Vida[5].color = new Color (1,1,1,1);
                break;
            default:
                Vida[0].color = new Color (1,1,1,1);
                Vida[1].color = new Color (1,1,1,1);
                Vida[2].color = new Color (1,1,1,1);
                Vida[3].color = new Color (0,0,0,0);
                Vida[4].color = new Color (0,0,0,0);
                Vida[5].color = new Color (0,0,0,0);
                break;
        }

    }
    void CalculoL()
    {
        if(exibe)
        {
            life = 3;  
        
            switch (VI)
            {
                case 0:
                    SceneManager.LoadScene(nomeScene);
                    Contador[0].color = new Color (1,1,1,1);
                    Contador[1].color = new Color (0,0,0,0);
                    Contador[2].color = new Color (0,0,0,0);
                    Contador[3].color = new Color (0,0,0,0);
                    Contador[4].color = new Color (0,0,0,0);
                    Contador[5].color = new Color (0,0,0,0);
                    Contador[6].color = new Color (0,0,0,0);
                    Contador[7].color = new Color (0,0,0,0);
                    Contador[8].color = new Color (0,0,0,0);
                    break;
                case 1:
                    Contador[0].color = new Color (1,1,1,1);
                    Contador[1].color = new Color (0,0,0,0);
                    Contador[2].color = new Color (0,0,0,0);
                    Contador[3].color = new Color (0,0,0,0);
                    Contador[4].color = new Color (0,0,0,0);
                    Contador[5].color = new Color (0,0,0,0);
                    Contador[6].color = new Color (0,0,0,0);
                    Contador[7].color = new Color (0,0,0,0);
                    Contador[8].color = new Color (0,0,0,0);
                    break;
                case 2:
                    Contador[0].color = new Color (0,0,0,0);
                    Contador[1].color = new Color (1,1,1,1);
                    Contador[2].color = new Color (0,0,0,0);
                    Contador[3].color = new Color (0,0,0,0);
                    Contador[4].color = new Color (0,0,0,0);
                    Contador[5].color = new Color (0,0,0,0);
                    Contador[6].color = new Color (0,0,0,0);
                    Contador[7].color = new Color (0,0,0,0);
                    Contador[8].color = new Color (0,0,0,0);
                    break;
                case 3:
                    Contador[0].color = new Color (0,0,0,0);
                    Contador[1].color = new Color (0,0,0,0);
                    Contador[2].color = new Color (1,1,1,1);
                    Contador[3].color = new Color (0,0,0,0);
                    Contador[4].color = new Color (0,0,0,0);
                    Contador[5].color = new Color (0,0,0,0);
                    Contador[6].color = new Color (0,0,0,0);
                    Contador[7].color = new Color (0,0,0,0);
                    Contador[8].color = new Color (0,0,0,0);
                    break;
                case 4:
                    Contador[0].color = new Color (0,0,0,0);
                    Contador[1].color = new Color (0,0,0,0);
                    Contador[2].color = new Color (0,0,0,0);
                    Contador[3].color = new Color (1,1,1,1);
                    Contador[4].color = new Color (0,0,0,0);
                    Contador[5].color = new Color (0,0,0,0);
                    Contador[6].color = new Color (0,0,0,0);
                    Contador[7].color = new Color (0,0,0,0);
                    Contador[8].color = new Color (0,0,0,0);
                    break;
                case 5:
                    Contador[0].color = new Color (0,0,0,0);
                    Contador[1].color = new Color (0,0,0,0);
                    Contador[2].color = new Color (0,0,0,0);
                    Contador[3].color = new Color (0,0,0,0);
                    Contador[4].color = new Color (1,1,1,1);
                    Contador[5].color = new Color (0,0,0,0);
                    Contador[6].color = new Color (0,0,0,0);
                    Contador[7].color = new Color (0,0,0,0);
                    Contador[8].color = new Color (0,0,0,0);
                    break;
                case 6:
                    Contador[0].color = new Color (0,0,0,0);
                    Contador[1].color = new Color (0,0,0,0);
                    Contador[2].color = new Color (0,0,0,0);
                    Contador[3].color = new Color (0,0,0,0);
                    Contador[4].color = new Color (0,0,0,0);
                    Contador[5].color = new Color (1,1,1,1);
                    Contador[6].color = new Color (0,0,0,0);
                    Contador[7].color = new Color (0,0,0,0);
                    Contador[8].color = new Color (0,0,0,0);
                    break;
                case 7:
                    Contador[0].color = new Color (0,0,0,0);
                    Contador[1].color = new Color (0,0,0,0);
                    Contador[2].color = new Color (0,0,0,0);
                    Contador[3].color = new Color (0,0,0,0);
                    Contador[4].color = new Color (0,0,0,0);
                    Contador[5].color = new Color (0,0,0,0);
                    Contador[6].color = new Color (1,1,1,1);
                    Contador[7].color = new Color (0,0,0,0);
                    Contador[8].color = new Color (0,0,0,0);
                    break;
                case 8:
                    Contador[0].color = new Color (0,0,0,0);
                    Contador[1].color = new Color (0,0,0,0);
                    Contador[2].color = new Color (0,0,0,0);
                    Contador[3].color = new Color (0,0,0,0);
                    Contador[4].color = new Color (0,0,0,0);
                    Contador[5].color = new Color (0,0,0,0);
                    Contador[6].color = new Color (0,0,0,0);
                    Contador[7].color = new Color (1,1,1,1);
                    Contador[8].color = new Color (0,0,0,0);
                    break;
                case 9:
                    Contador[0].color = new Color (0,0,0,0);
                    Contador[1].color = new Color (0,0,0,0);
                    Contador[2].color = new Color (0,0,0,0);
                    Contador[3].color = new Color (0,0,0,0);
                    Contador[4].color = new Color (0,0,0,0);
                    Contador[5].color = new Color (0,0,0,0);
                    Contador[6].color = new Color (0,0,0,0);
                    Contador[7].color = new Color (0,0,0,0);
                    Contador[8].color = new Color (1,1,1,1);
                    break;
                default:
                    Contador[0].color = new Color (0,0,0,0);
                    Contador[1].color = new Color (0,0,0,0);
                    Contador[2].color = new Color (0,0,0,0);
                    Contador[3].color = new Color (0,0,0,0);
                    Contador[4].color = new Color (0,0,0,0);
                    Contador[5].color = new Color (0,0,0,0);
                    Contador[6].color = new Color (0,0,0,0);
                    Contador[7].color = new Color (0,0,0,0);
                    Contador[8].color = new Color (1,1,1,1);
                    break;
            }
        }
        else
        {
            Contador[0].color = new Color (0,0,0,0);
            Contador[1].color = new Color (0,0,0,0);
            Contador[2].color = new Color (0,0,0,0);
            Contador[3].color = new Color (0,0,0,0);
            Contador[4].color = new Color (0,0,0,0);
            Contador[5].color = new Color (0,0,0,0);
            Contador[6].color = new Color (0,0,0,0);
            Contador[7].color = new Color (0,0,0,0);
            Contador[8].color = new Color (0,0,0,0);
        }

    }
    IEnumerator Num()
    {
        exibe = true;
        yield return new WaitForSeconds(3.3f);
        exibe = false;
        transform.position = respawn; 
    }
    IEnumerator Ini()
    {
        exibe = true;
        yield return new WaitForSeconds(2.5f);
        exibe = false;
        transform.position = respawn; 
    }

}
