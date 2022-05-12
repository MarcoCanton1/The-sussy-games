using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class QuienSeComiolatortilla : MonoBehaviour
{
    public Button sus1;
    public Button sus2;
    public Button sus3;
    public Button sus4;
    public Button sus5;
    public Image investigacion;
    public Image fondo;
    public float TiempoCountdown;
    public Text instrucciones;
    public Text numerado;
    public AudioSource audio;
    public AudioClip musica;
    public AudioClip bien;
    public AudioClip mal;
    public Image cagastes;
    public Image pillo;
    public bool investigacionA = false;
    void Start()
    {
        pillo.gameObject.SetActive(false);
        cagastes.gameObject.SetActive(false);  
        audio = gameObject.GetComponent<AudioSource>();
        //audio.volume = Introepica.vol;
        sus1.interactable = false;
        sus2.interactable = false;
        sus3.interactable = false;
        sus4.interactable = false;
        sus5.interactable = false;
        investigacion.gameObject.SetActive(false);
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
            sus1.interactable = true;
            sus2.interactable = true;
            sus3.interactable = true;
            sus4.interactable = true;
            sus5.interactable = true;
            fondo.gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space) && investigacionA == false)
            {
                instrucciones.gameObject.SetActive(false);
                investigacion.gameObject.SetActive(true);
                investigacionA = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && investigacionA == true)
            {
                instrucciones.gameObject.SetActive(true);
                investigacion.gameObject.SetActive(false);
                investigacionA = false;
            }
        }
    }

    public void Correcto()
    {
        audio.PlayOneShot(bien);
        pillo.gameObject.SetActive(true);
    }

    public void Incorrecto()
    {
        StartCoroutine(boludo());
    }

    IEnumerator boludo()
    {
        cagastes.gameObject.SetActive(true);
        audio.PlayOneShot(mal);
        yield return new WaitForSeconds(2);
        cagastes.gameObject.SetActive(false);
    }

    public void escena()
    {
        SceneManager.LoadScene("FinalM");
    }
}
