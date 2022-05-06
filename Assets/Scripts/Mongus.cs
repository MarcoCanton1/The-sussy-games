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
    public Text texto;
    void Start()
    {
        transparencia = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (emperador.color.a < 1)
        {
            StartCoroutine(aparicion());
        }
        else if (emperador.color.a == 1)
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