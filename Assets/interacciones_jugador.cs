using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class interacciones_jugador : MonoBehaviour
{
    [SerializeField] int vida=3;
    [SerializeField] float elPuntaje=0;
    [SerializeField] float puntaje=0;
    [SerializeField] TMP_Text text_puntaje;
    [SerializeField] TMP_Text text_vida;

    GameObject controlador;

    public GameObject ElControlador
    {
        get { return controlador; }
        set { controlador = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elPuntaje += Time.deltaTime;
        if(elPuntaje > 1)
        {
            puntaje += 1;
            elPuntaje = 0;
        }
        actualizarPuntaje();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "daño")
        {
            Debug.Log("holaaaaaaaaaaaaaa");
            vida -= 1;
            text_vida.text = "Vida: " + vida;

            if (vida <= 0)
            {
                controlador.GetComponent<controlador>().Termino = true;
                Destroy(gameObject);
                text_vida.text = "Vida: 0";
            } 
        }
        else if (collision.gameObject.tag == "punto")
        {
            ElControlador.GetComponent<controlador>().eliminar_punto();
            puntaje += 100;
            actualizarPuntaje();
        }
    }



    public void actualizarPuntaje()
    {
        if (puntaje < 10)
        {
            text_puntaje.text = "Puntaje: 000000" + puntaje;
        }
        else if (puntaje < 100)
        {
            text_puntaje.text = "Puntaje: 00000" + puntaje;
        }
        else if (puntaje < 1000)
        {
            text_puntaje.text = "Puntaje: 0000" + puntaje;
        }
        else if (puntaje < 10000)
        {
            text_puntaje.text = "Puntaje: 000" + puntaje;
        }
        else if (puntaje < 100000)
        {
            text_puntaje.text = "Puntaje: 00" + puntaje;
        }
        else if(puntaje < 1000000)
        {
            text_puntaje.text = "Puntaje: 0" + puntaje;
        }
        else if (puntaje < 10000000)
        {
            text_puntaje.text = "Puntaje: " + puntaje;
        }

    }


}
