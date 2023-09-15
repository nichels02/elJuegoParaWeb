using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetos : MonoBehaviour
{
    [SerializeField] Rigidbody2D MyRigidbody2D;
    [SerializeField] float velocidad;
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
            Destroy(gameObject);
        }
    }
}
