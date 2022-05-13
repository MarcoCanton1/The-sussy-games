using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Descubrimiento : MonoBehaviour
{
    public InputField code;
    public Image Resultado;
    void Start()
    {
        Resultado.gameObject.SetActive(false);
    }

    public void respuesta()
    {
        if (code.text == "46982")
        {
            Resultado.gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Pantalla");
        }
    }

    public void volver()
    {
        SceneManager.LoadScene("Pantalla");
    }
}
