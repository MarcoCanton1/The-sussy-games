using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

//sussy games B) :o
public class Introepica : MonoBehaviour
{
    //items
    public Text bienvenido;
    public Button iniciar;
    public Button config;
    public Button secreto1;
    public Image BC;
    public AudioSource musica;
    public GameObject contenedor;
    public Slider volumenM;
    public Dropdown cancion;
    public Dropdown graficos;
    public AudioClip song1;
    public AudioClip song2;
    string[] juegos = {"Bowl do amogus", "Nacimiento"};
    Random siguienteJ = new Random();
    int seleccion;
    //

    //metodos
    void Start()
    {
        secreto1.gameObject.SetActive(false);
        seleccion = UnityEngine.Random.Range(0, 4);
        BC.gameObject.SetActive(false);
        iniciar.gameObject.SetActive(false);
        config.gameObject.SetActive(false);
        bienvenido.fontSize = 0;
        musica = gameObject.GetComponent<AudioSource>();
        volumenM.value = musica.volume;
    }

    void Update()
    {
        PonerCalidad(graficos.value);
        musica.volume = volumenM.value;
        if (bienvenido.fontSize < 50)
        {
            StartCoroutine(aumentar());
        }
        else
        {
            config.gameObject.SetActive(true);
            iniciar.gameObject.SetActive(true);
        }

        if (cancion.value == 0 && musica.clip != song1)
        {
            musica.Stop();
            musica.clip = song1;
            musica.Play();
        }
        else if (cancion.value == 1 && musica.clip != song2)
        {
            musica.Stop();
            musica.clip = song2;
            musica.Play();
        }
        
        if (musica.volume == 1 && graficos.value == 0)
        {
            secreto1.gameObject.SetActive(true);
        }
    }

    IEnumerator aumentar()
    {
        bienvenido.fontSize++;
        yield return new WaitForSeconds(.5f);
    }

    public void configuracion()
    {
        iniciar.gameObject.SetActive(false);
        config.gameObject.SetActive(false);
        bienvenido.gameObject.SetActive(false);
        BC.gameObject.SetActive(true);
    }

    public void volver()
    {
        iniciar.gameObject.SetActive(true);
        config.gameObject.SetActive(true);
        bienvenido.gameObject.SetActive(true);
        BC.gameObject.SetActive(false);
    }
    //
    public void PonerCalidad(int nivelCalidad)
    {
        QualitySettings.SetQualityLevel(nivelCalidad);
    }

    public void Empezar()
    {
        SceneManager.LoadScene(juegos[seleccion]);
    }

    public void Chances()
    {
        SceneManager.LoadScene("Juicio");
    }
}
