using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativa : MonoBehaviour
{
    void Start()
    {
        Boss.instance.enabled = false; 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("hero"))
        {
            Boss.instance.enabled = true;
            if (Boss.instance.vira)
            {
                Boss.instance.bossRB.velocity = new Vector2(5, 0);
                Boss.instance.anim.Play("Boss_andando");
            }
            else
            {
                Boss.instance.bossRB.velocity = new Vector2(-5, 0);
                Boss.instance.anim.Play("Boss_andando");
            }  
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("hero"))
        {
            Boss.instance.core[0].color = new Color (0,0,0,0);
            Boss.instance.core[1].color = new Color (0,0,0,0);
            Boss.instance.core[2].color = new Color (0,0,0,0);
            Boss.instance.core[3].color = new Color (0,0,0,0);
            Boss.instance.core[4].color = new Color (0,0,0,0);
            Boss.instance.core[5].color = new Color (0,0,0,0);
            Boss.instance.core[6].color = new Color (0,0,0,0);
            Boss.instance.core[7].color = new Color (0,0,0,0);
            Boss.instance.core[8].color = new Color (0,0,0,0);
            Boss.instance.core[9].color = new Color (0,0,0,0);
            Boss.instance.core[10].color = new Color (0,0,0,0);
            Boss.instance.core[11].color = new Color (0,0,0,0);
            Boss.instance.core[12].color = new Color (0,0,0,0);
            Boss.instance.core[13].color = new Color (0,0,0,0);
            Boss.instance.core[14].color = new Color (0,0,0,0);
            Boss.instance.core[15].color = new Color (0,0,0,0);
            Boss.instance.core[16].color = new Color (0,0,0,0);
            Boss.instance.core[17].color = new Color (0,0,0,0);
            Boss.instance.core[18].color = new Color (0,0,0,0);
            Boss.instance.core[19].color = new Color (0,0,0,0);
            Boss.instance.core[20].color = new Color (0,0,0,0);
            Boss.instance.enabled = false; 
            Boss.instance.vida = 10;
            Boss.instance.bossRB.velocity = new Vector2(0, 0);
        }
    }
}
