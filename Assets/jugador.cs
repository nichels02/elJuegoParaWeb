using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour
{
    [SerializeField] Rigidbody2D MyRigidbody2D;
    [SerializeField] float velocidadMovimiento = 5.0f;
    int movimientoVertical=10;
    [SerializeField] bool puedeSaltar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && puedeSaltar == true)
        {
            print("hola");
            puedeSaltar = false;
            MyRigidbody2D.AddForce(movimientoVertical * Vector2.up, ForceMode2D.Impulse);
            velocidadMovimiento = 300;
        }

        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        //float movimientoVertical = Input.GetAxis("Vertical");
        
        

        float desplazamientoX = movimientoHorizontal * velocidadMovimiento * Time.deltaTime;
        //float desplazamientoY = movimientoVertical * velocidadMovimiento * Time.deltaTime;

        MyRigidbody2D.velocity = new Vector2(desplazamientoX, MyRigidbody2D.velocity.y);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            puedeSaltar = true;
            velocidadMovimiento = 500;
        }
    }
}
