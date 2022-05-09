using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TiempoCountdown = 100;
    public float TiempoR;
    public Text numerado;
    public Image pantalla;
    public Text tiempoR;
    public GameObject leche;
    public GameObject[] amongus;
    public Transform spawner;
    int seleccion;
    void Start()
    {
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
            if (TiempoR > 0)
            {
                //TiempoR -= Time.deltaTime;
                //tiempoR.text = TiempoR.ToString();
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Instantiate(amongus[Random.Range(0, amongus.Length)], spawner.position, spawner.rotation);
                }
            }
            else if (TiempoR <= 0)
            {
                perdiste();
            }
        }
    }

    public void perdiste()
    {

    }
}
