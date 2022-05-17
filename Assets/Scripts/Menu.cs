using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Volver()
    {
        SceneManager.LoadScene("Pantalla");
        Introepica.boton = true;
    }
}
