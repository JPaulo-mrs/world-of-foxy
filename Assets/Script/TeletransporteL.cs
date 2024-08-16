using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TeletransporteL : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private Tilemap tileAlvo;
    [SerializeField]
    private Image fundoP;
    //[SerializeField]
    //private GameObject animText;
    [SerializeField]
    private GameObject audioPF;

    private void Awake()
    {
        fundoP.enabled = false;
    }

    IEnumerator OnTriggerStay2D(Collider2D outro)
    {
        if((outro.gameObject.CompareTag("hero") && Input.GetKey(KeyCode.RightArrow)) || (outro.gameObject.CompareTag("hero") && Input.GetKey(KeyCode.D)))
        {
            fundoP.enabled = true;
            Animator anim = fundoP.GetComponent<Animator>();
            anim.Play("Transição");
            yield return new WaitForSeconds(0.1f);
            outro.transform.position = alvo.transform.GetChild(0).position;
            CSeguidora.instance.tileM = tileAlvo;
            CSeguidora.instance.StartMapa();
            anim.Play("Transição inv");
            //StartCoroutine(animText.GetComponent<TextMSG>().MostraTexto(tileAlvo.tag));
        }
    }


}
