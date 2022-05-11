using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Encuentralo : MonoBehaviour
{
    public Image pantalla;
    public float TiempoCountdown;
    public Text numerado;
    public Image fondo1;
    public Image fondo2;
    public Image fondo3;
    bool etapa1 = true;
    bool etapa2 = true;
    bool etapa3 = true;
    public Button spawn1;
    public Button spawn2;
    public Button spawn3;
    public AudioSource audio;
    public AudioClip musica;
    public AudioClip respuestaCorrectaSound;
    public Image bien;
    public float TiempoR;
    public Text tiempoR;
    bool empezo = false;
    public Button siguiente;
    public Image fondoG;
    public Text textitoUWU;
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.volume = Introepica.vol;
        bien.gameObject.SetActive(false);
        textitoUWU.gameObject.SetActive(false);
        fondoG.gameObject.SetActive(false);
        siguiente.gameObject.SetActive(false);
        fondo1.gameObject.SetActive(false);
        spawn1.gameObject.SetActive(false);
        fondo2.gameObject.SetActive(false);
        spawn2.gameObject.SetActive(false);
        fondo3.gameObject.SetActive(false);
        spawn3.gameObject.SetActive(false);
        pantalla.gameObject.SetActive(true);
        tiempoR.gameObject.SetActive(false);
    }

    void Update()
    {
        if (TiempoCountdown > 0)
        {
            TiempoCountdown -= Time.deltaTime;
            numerado.text = TiempoCountdown.ToString();
        }
        else if (TiempoCountdown <= 0 && empezo == false)
        {
            pantalla.gameObject.SetActive(false);
            etapa1 = false;
        }

        if (TiempoR > 0)
        {
            TiempoR -= Time.deltaTime;
            tiempoR.text = TiempoR.ToString();
        }
        else if (TiempoR <= 0)
        {
            perder();
        }

        if (TiempoR >= 0 && etapa1 == false)
        {
            TiempoR = 30;
            empezo = true;
            tiempoR.gameObject.SetActive(true);
            fondo1.gameObject.SetActive(true);
            spawn1.gameObject.SetActive(true);
            etapa1 = true;
        }
        if (TiempoR >= 0 && etapa2 == false)
        {
            etapa1 = true;
            fondo1.gameObject.SetActive(false);
            spawn1.gameObject.SetActive(false);
            TiempoR = 30;
            fondo2.gameObject.SetActive(true);
            spawn2.gameObject.SetActive(true);
            etapa2 = true;
        }
        if (TiempoR >= 0 && etapa3 == false)
        {
            etapa1 = true;
            fondo1.gameObject.SetActive(false);
            spawn1.gameObject.SetActive(false);
            fondo2.gameObject.SetActive(false);
            spawn2.gameObject.SetActive(false);
            TiempoR = 30;
            fondo3.gameObject.SetActive(true);
            spawn3.gameObject.SetActive(true);
            spawn3.interactable = true;
            etapa3 = true;
        }
    }

    public void perder()
    {

    }

    public void E1()
    {
        etapa2 = false;
        StartCoroutine(Bien());
    }
    public void E2()
    {
        etapa3 = false;
        StartCoroutine(Bien());
    }
    public void E3()
    {
        fondo1.gameObject.SetActive(false);
        spawn1.gameObject.SetActive(false);
        fondo2.gameObject.SetActive(false);
        spawn2.gameObject.SetActive(false);
        fondo3.gameObject.SetActive(false);
        spawn3.gameObject.SetActive(false);
        pantalla.gameObject.SetActive(false);
        tiempoR.gameObject.SetActive(false);
        textitoUWU.gameObject.SetActive(true);
        fondoG.gameObject.SetActive(true);
        siguiente.gameObject.SetActive(true);
        StartCoroutine(Bien());
    }
    
    IEnumerator Bien()
    {
        bien.gameObject.SetActive(true);
        audio.PlayOneShot(respuestaCorrectaSound, 1);
        yield return new WaitForSeconds(2);
        bien.gameObject.SetActive(false);
    }



    public void ahoraSi()
    {
        SceneManager.LoadScene("Quien");
    }
}
