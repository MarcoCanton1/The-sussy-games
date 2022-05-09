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
    public Button secreto2;
    public Button risa;
    public float TiempoS2;
    public AudioSource musica;
    public GameObject contenedor;
    public Slider volumenM;
    public static float vol;
    public Dropdown cancion;
    public Dropdown graficos;
    public Image instrucciones;
    Color tempColor;
    float transparencia = 0;
    public Button inicioP;
    public Image risaIMG;
    public Toggle cookies;
    public Image bien;
    bool etapa1 = false;
    bool etapa2 = false;
    bool etapa3 = false;
    bool etapa4 = false;
    public AudioClip song1;
    public AudioClip song2;
    public string[] juegos = {"Bowl do amogus", "Nacimiento"};
    Random siguienteJ = new Random();
    int seleccion;
    //

    //metodos
    void Start()
    {
        
        risaIMG = risa.GetComponent<Image>();
        secreto1.gameObject.SetActive(false);
        secreto2.gameObject.SetActive(false);
        seleccion = UnityEngine.Random.Range(0, 4);
        BC.gameObject.SetActive(false);
        instrucciones.gameObject.SetActive(false);
        iniciar.gameObject.SetActive(false);
        config.gameObject.SetActive(false);
        bienvenido.fontSize = 0;
        musica = gameObject.GetComponent<AudioSource>();
        volumenM.value = musica.volume;
        risa.gameObject.SetActive(false);
    }

    void Update()
    {
        PonerCalidad(graficos.value);
        musica.volume = volumenM.value;
        vol = volumenM.value;
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

        if (cookies.isOn == false)
        {
            inicioP.interactable = false;
            bien.gameObject.SetActive(false);
        }
        else if (cookies.isOn == true)
        {
            inicioP.interactable = true;
            bien.gameObject.SetActive(true);
        }

        if (TiempoS2 > -100)
        {
            TiempoS2 -= Time.deltaTime;
        }
        else if (TiempoS2 <= 0 && TiempoS2 > -25)
        {
            secreto2.gameObject.SetActive(true);
            BC.gameObject.SetActive(false);
            instrucciones.gameObject.SetActive(false);
            iniciar.gameObject.SetActive(false);
            config.gameObject.SetActive(false);
            bienvenido.gameObject.SetActive(false);
            secreto1.gameObject.SetActive(false);
            risa.interactable = false;
        }
        else if (TiempoS2 == -25 && etapa1 == false)
        {
            secreto2.interactable = false;
            transparencia += .25f;
            etapa1 = true;
        }
        else if (TiempoS2 < -25 && TiempoS2 > -50 && etapa2 == false)
        {
            transparencia += .25f;
            etapa2 = true;
        }
        else if (TiempoS2 < -50 && TiempoS2 > -100 && etapa3 == false)
        {
            transparencia += .25f;
            etapa3 = true;
        }
        else if (TiempoS2 >= -100 && etapa4 == false)
        {
            transparencia += .25f;
            etapa4 = true;
            risa.interactable = true;
        }
        tempColor = risaIMG.color;
        tempColor.a = transparencia;
        risaIMG.color = tempColor;

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
        instrucciones.gameObject.SetActive(true);
        inicioP.interactable = false;
        bien.gameObject.SetActive(false);
    }

    public void Chances()
    {
        SceneManager.LoadScene("Juicio");
    }

    public void ahoraSi()
    {
        SceneManager.LoadScene(juegos[0]);
    }

    public void secret2()
    {
        SceneManager.LoadScene("troleo");
    }

    public void screamerxd()
    {

    }
}
