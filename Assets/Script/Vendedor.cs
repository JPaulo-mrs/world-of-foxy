using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vendedor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private SpriteRenderer[] oferta;
    void Start()
    {
        oferta[0].color = new Color (0,0,0,0);
        oferta[1].color = new Color (0,0,0,0);
        oferta[2].color = new Color (0,0,0,0);
        oferta[3].color = new Color (0,0,0,0);
        oferta[4].color = new Color (0,0,0,0);
        oferta[5].color = new Color (0,0,0,0);
        oferta[6].color = new Color (0,0,0,0);
        oferta[7].color = new Color (0,0,0,0);
        oferta[8].color = new Color (0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {     
 
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("hero"))
        {
            oferta[0].color = new Color (1,1,1,1);
            oferta[1].color = new Color (1,1,1,1);
            oferta[2].color = new Color (1,1,1,1);
            oferta[3].color = new Color (1,1,1,1);
            oferta[4].color = new Color (1,1,1,1);
            oferta[5].color = new Color (1,1,1,1);
            oferta[6].color = new Color (1,1,1,1);
            oferta[7].color = new Color (1,1,1,1);
            oferta[8].color = new Color (1,1,1,1);   
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("hero"))
        {
            oferta[0].color = new Color (0,0,0,0);
            oferta[1].color = new Color (0,0,0,0);
            oferta[2].color = new Color (0,0,0,0);
            oferta[3].color = new Color (0,0,0,0);
            oferta[4].color = new Color (0,0,0,0);
            oferta[5].color = new Color (0,0,0,0);
            oferta[6].color = new Color (0,0,0,0);
            oferta[7].color = new Color (0,0,0,0);
            oferta[8].color = new Color (0,0,0,0);    
        }
    }
}
