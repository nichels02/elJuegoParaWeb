using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class objetos : MonoBehaviour
{
    [SerializeField] Rigidbody2D MyRigidbody2D;
    [SerializeField] float velocidad;
    GameObject controlador;


    float tiempo = 0;

    public GameObject ElControlador
    {
        get { return controlador; }
        set { controlador = value; }
    }


    public float Velocidad
    {
        get { return velocidad; }
        set { velocidad = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        MyRigidbody2D.velocity = new Vector2(0, velocidad);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "eliminador")
        {
            if (gameObject.tag == "daño")
            {
                controlador.GetComponent<controlador>().eliminar_daño();
            }
            else if(gameObject.tag == "punto")
            {
                controlador.GetComponent<controlador>().eliminar_punto();
            }
        }
    }
}
