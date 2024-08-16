using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    [SerializeField]
    private Animator bl;
    private bool colect;
    //[SerializeField]
    //private GameObject coinPF;
    
    // Start is called before the first frame update
    void Start()
    {
        colect = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cabeçada"))
        {
            if (colect)
            {
                bl.Play("Quebrabo");
                UI.instance.gold += 5;
                colect = false;
            }
        }
    }
}
