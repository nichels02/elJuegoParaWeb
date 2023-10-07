using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject ElJugador;
    [SerializeField] TMP_Text texto;
    int cantidadDeHabilidades=3;

    bool lahabilidad;
    bool aparecerYdesaparecer;
    float duracion;
    float velocidadDeCambio=3;
    Color jugadorColor;
    Color jugadorColorGuardado;

    // Start is called before the first frame update
    void Start()
    {
        
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
                if (jugadorColor.a <= 0.2)
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
                if (jugadorColor.a >= 0.8)
                {
                    aparecerYdesaparecer = true;
                }
            }
            if (duracion > 8)
            {
                ElJugador.GetComponent<interacciones_jugador>().LaHabilidadEstaPrendida = false;
                lahabilidad = false;
                ElJugador.GetComponent<SpriteRenderer>().color = jugadorColorGuardado;
            }
        }
        
    }





    void crear_mensaje()
    {
        if (cantidadDeHabilidades > 0)
        {
            duracion = 0;
            cantidadDeHabilidades -= 1;
            texto.text = "Power up: " + cantidadDeHabilidades;
            lahabilidad = true;
            aparecerYdesaparecer = true;



            jugadorColor = ElJugador.GetComponent<SpriteRenderer>().color;
            jugadorColorGuardado = ElJugador.GetComponent<SpriteRenderer>().color;
            jugadorColor = Color.green;
            ElJugador.GetComponent<SpriteRenderer>().color = jugadorColor;
        }
    }


}
