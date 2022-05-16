using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Moverse : MonoBehaviour
{
    public float velMov;
    public Transform orientacion;
    float Inputhotizontal;
    float Inputvertical;
    public float altura;
    public LayerMask piso;
    bool sentao;
    public float arrastrasuelo;
    public Image susto;
    public AudioSource audio;
    public AudioSource atacama;
    public AudioClip cuidado;
    public InputField code;
    bool ending = false;

    Vector3 DireccionMov;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        susto.gameObject.SetActive(false);
        audio.gameObject.GetComponent<AudioSource>();
        code.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        sentao = Physics.Raycast(transform.position, Vector3.down, altura * 0.5f + 0.2f, piso);
        Inputa();
        control();
        if (sentao)
        {
            rb.drag = arrastrasuelo;
        }
        else
        {
            rb.drag = 0;
        }
        if (code.text == "46982" && ending == false)
        {
            SceneManager.LoadScene("GoodEnding");
        }
        else if (code.text == "46982" && ending == true)
        {
            SceneManager.LoadScene("TrueEnding");
        }
    }

    private void FixedUpdate()
    {
        Moverla();
    }

    private void Inputa()
    {
        Inputhotizontal = Input.GetAxisRaw("Horizontal");
        Inputvertical = Input.GetAxisRaw("Vertical");
    }

    private void Moverla()
    {
        DireccionMov = orientacion.forward * Inputvertical + orientacion.right * Inputhotizontal;
        rb.AddForce(DireccionMov.normalized * velMov * 10f, ForceMode.Force);
    }

    private void control()
    {
        Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatvel.magnitude > velMov)
        {
            Vector3 limite = flatvel.normalized * velMov;
            rb.velocity = new Vector3(limite.x, rb.velocity.y, limite.z);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "atacama")
        {
            StartCoroutine(screamer());
        }

        if (col.gameObject.name == "salvacion")
        {
            atacama.gameObject.SetActive(false);
            code.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else if (col.gameObject.name == "salvacion" && ending == true)
        {
            atacama.gameObject.SetActive(false);
            code.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        if (col.gameObject.name == "sussy")
        {
            Debug.Log("si");
            ending = true;
        }
    }

    IEnumerator screamer()
    {
        atacama.mute = true;
        susto.gameObject.SetActive(true);
        audio.PlayOneShot(cuidado, 0.5f);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("BadEnding");
    }
}
