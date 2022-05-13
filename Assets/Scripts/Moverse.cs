using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    Vector3 DireccionMov;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
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
}
