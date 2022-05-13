using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    public Transform posicionC;
    void Update()
    {
        transform.position = posicionC.position;
    }
}
