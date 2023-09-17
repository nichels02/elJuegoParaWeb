using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generador : MonoBehaviour
{
    [SerializeField] GameObject controlador;
    [SerializeField] GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        GameObject a= Instantiate(controlador);
        jugador.GetComponent<interacciones_jugador>().ElControlador=a;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
