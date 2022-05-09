using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float TiempoCountdown = 100;
    public float TiempoR;
    public Camera camara;
    public Text numerado;
    public Image pantalla;
    public Text tiempoR;
    public GameObject leche;
    public GameObject[] amongus;
    public Transform spawner;
    public Transform caamara;
    public Text cantidadMax;
    public Button avanza;
    public Text enjoy;
    int cantidad;
    int seleccion;
    void Start()
    {
        avanza.gameObject.SetActive(false);
        enjoy.gameObject.SetActive(false);
        cantidadMax.gameObject.SetActive(false);
        tiempoR.gameObject.SetActive(false);
        pantalla.gameObject.SetActive(true);
        leche.gameObject.SetActive(false);
    }

    void Update()
    {
        seleccion = UnityEngine.Random.Range(0, 6);
        if (TiempoCountdown > 0)
        {
            TiempoCountdown -= Time.deltaTime;
            numerado.text = TiempoCountdown.ToString();
        }
        else if (TiempoCountdown <= 0)
        {
            pantalla.gameObject.SetActive(false);
            cantidadMax.gameObject.SetActive(true);
            tiempoR.gameObject.SetActive(true);
            if (TiempoR > 0)
            {
                TiempoR -= Time.deltaTime;
                tiempoR.text = TiempoR.ToString();
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Instantiate(amongus[Random.Range(0, amongus.Length)], spawner.position, spawner.rotation);
                    cantidad++;
                    cantidadMax.text = (cantidad.ToString() + "/100");
                }
            }
            else if (TiempoR <= 0 && cantidad < 100)
            {
                perdiste();
            }

            if (cantidad >= 100)
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
        cantidadMax.gameObject.SetActive(false);
        tiempoR.gameObject.SetActive(false);
        camara.transform.position = caamara.position;
        camara.transform.rotation = caamara.rotation;
        leche.gameObject.SetActive(true);
        if (leche.transform.position.y < 6.25f)
        {
            leche.transform.position += Vector3.up;
        }
        else if (leche.transform.position.y >= 6.25f)
        {
            enjoy.gameObject.SetActive(true);
            avanza.gameObject.SetActive(true);
        }
        

    }

    public void avanzar()
    {
        SceneManager.LoadScene("Nacimiento");
    }
}
