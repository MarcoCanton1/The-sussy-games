using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public Transform jugador;
    public NavMeshAgent agente;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(jugador.position);
    }
}
