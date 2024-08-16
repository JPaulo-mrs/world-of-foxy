using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField]
    private Animator plat;
    [SerializeField]
    private GameObject platPF;
    [SerializeField]
    private Vector3 posin;

    // Start is called before the first frame update
    void Start()
    {
        posin = transform.position;
    }

    IEnumerator  OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hero"))
        {
            plat.Play("vazio");
            yield return new  WaitForSeconds(0.5f);
            //plat.Play("plataforma");
        }
    }
    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destruir"))
        {
            yield return new  WaitForSeconds(2f);
            Instantiate(platPF, posin, Quaternion.identity);
            yield return new  WaitForSeconds(0.5f);
            Destroy(gameObject); 
        }
    }
}