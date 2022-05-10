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
    bool etapa1 = false;
    bool etapa2 = true;
    bool etapa3 = true;
    public Button spawn1;
    public Button spawn2;
    public Button spawn3;
    public float TiempoR;
    public Text tiempoR;
    void Start()
    {
        fondo1.gameObject.SetActive(false);
        spawn1.gameObject.SetActive(false);
        fondo2.gameObject.SetActive(false);
        spawn2.gameObject.SetActive(false);
        fondo3.gameObject.SetActive(false);
        spawn3.gameObject.SetActive(false);

    }

    // Update is called once per frame
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
        }

        if (TiempoCountdown <= 0 && etapa1 == false)
        {
            fondo1.gameObject.SetActive(true);
            spawn1.gameObject.SetActive(true);
            if (TiempoR > 0)
            {
                TiempoR -= Time.deltaTime;
                tiempoR.text = TiempoR.ToString();
            }
            else if (TiempoR <= 0)
            {
                perder();
            }
            etapa1 = true;

        }
        else if (TiempoCountdown <= 0 && etapa2 == false)
        {
            TiempoR = 30;
            fondo2.gameObject.SetActive(true);
            spawn2.gameObject.SetActive(true);
            if (TiempoR > 0)
            {
                TiempoR -= Time.deltaTime;
                tiempoR.text = TiempoR.ToString();
            }
            else if (TiempoR <= 0)
            {
                perder();
            }
            etapa2 = true;
        }
        else if (TiempoCountdown <= 0 && etapa3 == false)
        {
            TiempoR = 30;
            fondo3.gameObject.SetActive(true);
            spawn3.gameObject.SetActive(true);
            if (TiempoR > 0)
            {
                TiempoR -= Time.deltaTime;
                tiempoR.text = TiempoR.ToString();
            }
            else if (TiempoR <= 0)
            {
                perder();
            }
            etapa3 = true;
        }
    }

    public void perder()
    {

    }

    public void E1()
    {
        etapa2 = false;
    }
    public void E2()
    {
        etapa3 = false;
    }
    public void E3()
    {
        ganar();
    }

    public void ganar()
    {

    }
}
