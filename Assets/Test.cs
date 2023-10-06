using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject ElJugador;
    int cantidadDeHabilidades;

    bool lahabilidad;
    bool aparecerYdesaparecer;
    float duracion;
    float velocidadDeCambio=50;
    Color jugadorColor;

    // Start is called before the first frame update
    void Start()
    {
        crear_mensaje();
    }

    // Update is called once per frame
    void Update()
    {
        if(lahabilidad == true)
        {
            duracion += Time.deltaTime;
            ElJugador.GetComponent<interacciones_jugador>().LaHabilidadEstaPrendida = true;

            if (aparecerYdesaparecer == true)
            {
                jugadorColor = ElJugador.GetComponent<SpriteRenderer>().color;
                jugadorColor.a -= Time.deltaTime * velocidadDeCambio;
                ElJugador.GetComponent<SpriteRenderer>().color = jugadorColor;
                Debug.Log(jugadorColor.a);
                if (jugadorColor.a <= 0)
                {
                    aparecerYdesaparecer = false;
                }
            }
            else
            {
                jugadorColor = ElJugador.GetComponent<SpriteRenderer>().color;
                jugadorColor.a += Time.deltaTime * velocidadDeCambio;
                ElJugador.GetComponent<SpriteRenderer>().color = jugadorColor;
                Debug.Log(jugadorColor.a);
                if (jugadorColor.a >= 200)
                {
                    aparecerYdesaparecer = true;
                }
            }
            if (duracion > 10000)
            {
                ElJugador.GetComponent<interacciones_jugador>().LaHabilidadEstaPrendida = false;
                lahabilidad = false;
            }
        }
        
    }





    void crear_mensaje()
    {
        lahabilidad = true;
        aparecerYdesaparecer = true;
    }



    void aparecer()
    {
        Debug.Log("aparecer");
        Color jugadorColor = ElJugador.GetComponent<SpriteRenderer>().color;
        jugadorColor.a -= Time.deltaTime * velocidadDeCambio; 
        ElJugador.GetComponent<SpriteRenderer>().color = jugadorColor;
        if (jugadorColor.a <= 50)
        {
            aparecerYdesaparecer = false;
        }
    }
    
    
    void desaparecer()
    {
        Debug.Log("desaparecer");
        Color jugadorColor = ElJugador.GetComponent<SpriteRenderer>().color;
        jugadorColor.a += Time.deltaTime * velocidadDeCambio;
        ElJugador.GetComponent<SpriteRenderer>().color = jugadorColor;
        if (jugadorColor.a >= 200)
        {
            aparecerYdesaparecer = true;
        }
    }
}
