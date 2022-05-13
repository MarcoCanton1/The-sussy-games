using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public float ejeX;
    public float ejeY;
    float rotacionX;
    float rotacionY;
    public Transform direccion;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * ejeX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ejeY;
        rotacionY += mouseX;
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);
        transform.rotation = Quaternion.Euler(rotacionX, rotacionY, 0);
        direccion.rotation = Quaternion.Euler(0, rotacionY, 0);
    }
}
