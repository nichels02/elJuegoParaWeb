using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador : MonoBehaviour
{
    [Header("objetos")]
    [SerializeField] GameObject punto;
    [SerializeField] GameObject daño;


    [Header("tiempo")]
    [SerializeField] float time_daño;
    [SerializeField] float time_punto;
    [SerializeField] float periodo_daño=0.3f;
    [SerializeField] float periodo_punto=4;
    [SerializeField] float ElTiempo=2.8f;
    [SerializeField] float Tiempo=0;
    float a = 2.9f;
    float b = 0.8f;
    float c = 1.1f;
    [SerializeField]float x;
    


    [Header("listas")]
    LinkedList<GameObject> objetosDeDaño = new LinkedList<GameObject>();
    LinkedList<GameObject> objetosDeDañoActivo = new LinkedList<GameObject>();

    LinkedList<GameObject> objetosDePunto = new LinkedList<GameObject>();
    LinkedList<GameObject> objetosDePuntoActivo = new LinkedList<GameObject>();



    List<GameObject> objetos = new List<GameObject>();


    [Header("extra")]
    float random;
    bool termino = false;
    float veces_repetida = 0;

    public bool Termino
    {
        get { return termino; }
        set { termino = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        ElTiempo = 13f;
        for (int i=0; i < 60; i++)
        {
            GameObject a = Instantiate(daño, new Vector3(random, 6, 0), Quaternion.identity);
            a.gameObject.SetActive(false);
            a.gameObject.name = ""+i;
            a.GetComponent<objetos>().ElControlador=gameObject;
            objetosDeDaño.AddFirst(a);
            objetos.Add(a);
        }
        



        for (int i = 0; i < 2; i++)
        {
            GameObject a = Instantiate(punto, new Vector3(random, 6, 0), Quaternion.identity);
            a.gameObject.SetActive(false);
            a.gameObject.name = "" + i;
            a.GetComponent<objetos>().ElControlador = gameObject;
            objetosDePunto.AddFirst(a);
            objetos.Add(a);
        }


    }



    // Update is called once per frame
    void Update()
    {
        if (termino == false)
        {



            time_daño += Time.deltaTime;
            time_punto += Time.deltaTime;
            ElTiempo += Time.deltaTime / 5;
            Tiempo += Time.deltaTime;

            if (veces_repetida < 5)
            {
                if (Tiempo > 10)
                {
                    aumentar_velocidad();
                    Tiempo = 0;
                }

            }
            



            x = a * Mathf.Pow(b, ElTiempo) + 0.09f;



            if (time_daño > periodo_daño)
            {
                //random = Random.Range(-10.6f, 10.6f);
                //Instantiate(daño, new Vector3(random, 6, 0), Quaternion.identity);
                crear_daño();
                time_daño = 0;
                periodo_daño = x;
            }

            if (time_punto > 4)
            {
                crear_Punto();
                time_punto = 0;
            }
        }
    }




    void aumentar_velocidad()
    {
        for (int i = 0; i < 62; i++)
        {
            objetos[i].GetComponent<objetos>().Velocidad -= 1;
        }
        veces_repetida += 1;
    }



    void crear_daño()
    {
        random = Random.Range(-10.6f, 10.6f);
        //objetosDeDañoActivo.AddLast(objetosDeDaño.First.Value.gameObject.gameObject);
        //objetosDeDaño.RemoveFirst();

        LinkedListNode<GameObject> nodoATransferir = objetosDeDaño.First;
        objetosDeDañoActivo.AddLast(nodoATransferir.Value);
        
        
        //Debug.Log(objetosDeDaño.Count);
        
        
        objetosDeDaño.RemoveFirst();

        objetosDeDañoActivo.Last.Value.gameObject.transform.position = new Vector3(random, 6, 0);
        objetosDeDañoActivo.Last.Value.gameObject.SetActive(true);
    }
    public void eliminar_daño()
    {
        //objetosDeDaño.AddLast(objetosDeDañoActivo.First.Value.gameObject.gameObject.gameObject.gameObject);
        //objetosDeDañoActivo.RemoveFirst();


        //Debug.Log(objetosDeDaño.Count);
        
        
        LinkedListNode<GameObject> nodoATransferir = objetosDeDañoActivo.First;
        objetosDeDaño.AddLast(nodoATransferir.Value);
        objetosDeDañoActivo.RemoveFirst();


        objetosDeDaño.Last.Value.gameObject.SetActive(false);
    }






    void crear_Punto()
    {
        random = Random.Range(-10.6f, 10.6f);
        //objetosDeDañoActivo.AddLast(objetosDeDaño.First.Value.gameObject.gameObject);
        //objetosDeDaño.RemoveFirst();

        LinkedListNode<GameObject> nodoATransferir = objetosDePunto.First;
        objetosDePuntoActivo.AddLast(nodoATransferir.Value);


        //Debug.Log(objetosDeDaño.Count);


        objetosDeDaño.RemoveFirst();

        objetosDePuntoActivo.Last.Value.gameObject.transform.position = new Vector3(random, 6, 0);
        objetosDePuntoActivo.Last.Value.gameObject.SetActive(true);
    }
    public void eliminar_punto()
    {
        //objetosDeDaño.AddLast(objetosDeDañoActivo.First.Value.gameObject.gameObject.gameObject.gameObject);
        //objetosDeDañoActivo.RemoveFirst();


        //Debug.Log(objetosDeDaño.Count);


        LinkedListNode<GameObject> nodoATransferir = objetosDePuntoActivo.First;
        objetosDePunto.AddLast(nodoATransferir.Value);
        objetosDePuntoActivo.RemoveFirst();


        objetosDePunto.Last.Value.gameObject.SetActive(false);
    }
}
