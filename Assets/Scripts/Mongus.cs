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
    public AudioClip cancion;
    public GameObject texto;
    public Button opcion1;
    public Button opcion2;
    public Text si;
    bool respuesta;
    bool caca;
    int etapa = 0;
    void Start()
    {
        conversacion = gameObject.GetComponent<AudioSource>();
        conversacion.volume = Introepica.vol;
        transparencia = 0;
        texto.gameObject.SetActive(false);
        opcion1.gameObject.SetActive(false);
        opcion2.gameObject.SetActive(false);
        caca = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (emperador.color.a < 1)
        {
            StartCoroutine(aparicion());
        }

        if (emperador.color.a == 1 && etapa == 0)
        {
            texto.gameObject.SetActive(false);
            opcion1.gameObject.SetActive(false);
            opcion2.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && etapa < 3)
        {
            etapa++;
            conversacion.PlayOneShot(dialogo, 1);
            caca = false;
        }

        if (etapa == 1)
        {
            texto.gameObject.SetActive(true);
            si.text = "اهلا";
            caca = false;
        }
        else if (etapa == 2)
        {
            si.text = "هذا المكان لا يمثل أي قيمة";
            caca = false;
        }
        else if (etapa == 3)
        {
            si.text = "من هو اهم اله";
            texto.gameObject.SetActive(false);
            opcion1.gameObject.SetActive(true);
            opcion2.gameObject.SetActive(true);
        }

        if (respuesta == true)
        {
            opcion1.gameObject.SetActive(false);
            opcion2.gameObject.SetActive(false);
            texto.gameObject.SetActive(true);
            si.text = "46982";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Pantalla");
            }
        }
        else if (respuesta == false && caca == true)
        {
            opcion1.gameObject.SetActive(false);
            opcion2.gameObject.SetActive(false);
            SceneManager.LoadScene("Pantalla");
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

    public void correcto()
    {
        opcion1.gameObject.SetActive(false);
        opcion2.gameObject.SetActive(false);
        respuesta = true;
    }
    public void incorrecto()
    {
        opcion1.gameObject.SetActive(false);
        opcion2.gameObject.SetActive(false);
        respuesta = false;
        caca = true;
    }
}