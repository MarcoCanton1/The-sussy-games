using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class Nacer : MonoBehaviour
{
    public Image impostor;
    public Image cara;
    public Slider apunta;
    public Image pantalla;
    public Text ganar;
    public Button siguiente;
    public Text numerado;
    Color tempColor;
    float transparencia = 0;
    bool volviendo = false;
    public float TiempoCountdown;
    void Start()
    {
        cara.gameObject.SetActive(false);
        pantalla.gameObject.SetActive(true);
        ganar.gameObject.SetActive(false);
        siguiente.gameObject.SetActive(false);
        apunta.value = 0;
    }

    void Update()
    {
        if (TiempoCountdown > 0)
        {
            TiempoCountdown -= Time.deltaTime;
            numerado.text = TiempoCountdown.ToString();
        }
        else if (TiempoCountdown <= 0)
        {
            pantalla.gameObject.SetActive(false);
            if (apunta.value < 1 && volviendo == false)
            {
                apunta.value += Time.deltaTime;
            }
            else if (apunta.value >= 1)
            {
                volviendo = true;
            }

            if (apunta.value > 0 && volviendo == true)
            {
                apunta.value -= Time.deltaTime;
            }
            else if (apunta.value <= 0)
            {
                volviendo = false;
            }



            if (Input.GetKeyDown(KeyCode.Space) && apunta.value >= 0.4f && apunta.value <= 0.6f)
            {
                transparencia += .25f;
                apunta.value = 0;
                cara.gameObject.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Space) && apunta.value < 0.4f || Input.GetKeyDown(KeyCode.Space) && apunta.value > 0.6f)
            {
                Debug.Log("el pepe");
                perdiste();
            }
            tempColor = impostor.color;
            tempColor.a = transparencia;
            impostor.color = tempColor;

            if(transparencia == 1)
            {
                ganaste();
            }
        }


    } 

    public void perdiste()
    {
        SceneManager.LoadScene("Perder");
    }
    public void ganaste()
    {
        apunta.gameObject.SetActive(false);
        cara.gameObject.SetActive(false);
        impostor.gameObject.SetActive(false);
        siguiente.gameObject.SetActive(true);
        ganar.gameObject.SetActive(true);
    }

    public void avanzar()
    {
        SceneManager.LoadScene("Encuentra");
    }
}
