using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Mongus : MonoBehaviour
{
    float transparencia;
    public Image emperador;
    Color tempColor;
    public AudioSource conversacion;
    public AudioClip dialogo;
    public GameObject texto;
    public Text si;
    bool comienzo;
    int etapa;
    void Start()
    {
        comienzo = false;
        transparencia = 0;
        texto.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (emperador.color.a < 1)
        {
            StartCoroutine(aparicion());
        }
        else if (emperador.color.a == 1 && comienzo == false)
        {
            texto.gameObject.SetActive(true);
            comienzo = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            etapa++;
        }

        if (etapa == 1)
        {
            si.text = "هذا المكان لا يمثل أي قيمة";
        }
        else if (etapa == 2)
        {

        }
        tempColor = emperador.color;
        tempColor.a = transparencia;
        emperador.color = tempColor;    
    }

    IEnumerator aparicion()
    {
        transparencia += .01f;
        yield return new WaitForSeconds(.5f);
    }
}