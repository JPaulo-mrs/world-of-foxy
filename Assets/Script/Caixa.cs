using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour
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
    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pisada"))
        {
            if (colect)
            {
                bl.Play("DesCaixa");
                yield return new WaitForSeconds(0.6f);
                Destroy(gameObject);
            }
        }
    }
}