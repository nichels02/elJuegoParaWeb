using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador : MonoBehaviour
{
    [Header("objetos")]
    [SerializeField] GameObject punto;
    [SerializeField] GameObject da�o;


    [Header("tiempo")]
    [SerializeField] float time_da�o;
    [SerializeField] float time_punto;
    [SerializeField] float periodo_da�o=0.3f;
    [SerializeField] float periodo_punto=4;
    [SerializeField] float ElTiempo=2.8f;
    [SerializeField] float Tiempo=0;
    float a = 2.9f;
    float b = 0.8f;
    float c = 1.1f;
    [SerializeField]float x;
    


    [Header("listas")]
    LinkedList<GameObject> objetosDeDa�o = new LinkedList<GameObject>();
    LinkedList<GameObject> objetosDeDa�oActivo = new LinkedList<GameObject>();

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
            GameObject a = Instantiate(da�o, new Vector3(random, 6, 0), Quaternion.identity);
            a.gameObject.SetActive(false);
            a.gameObject.name = ""+i;
            a.GetComponent<objetos>().ElControlador=gameObject;
            objetosDeDa�o.AddFirst(a);
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



            time_da�o += Time.deltaTime;
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



            if (time_da�o > periodo_da�o)
            {
                //random = Random.Range(-10.6f, 10.6f);
                //Instantiate(da�o, new Vector3(random, 6, 0), Quaternion.identity);
                crear_da�o();
                time_da�o = 0;
                periodo_da�o = x;
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



    void crear_da�o()
    {
        random = Random.Range(-10.6f, 10.6f);
        //objetosDeDa�oActivo.AddLast(objetosDeDa�o.First.Value.gameObject.gameObject);
        //objetosDeDa�o.RemoveFirst();

        LinkedListNode<GameObject> nodoATransferir = objetosDeDa�o.First;
        objetosDeDa�oActivo.AddLast(nodoATransferir.Value);
        
        
        //Debug.Log(objetosDeDa�o.Count);
        
        
        objetosDeDa�o.RemoveFirst();

        objetosDeDa�oActivo.Last.Value.gameObject.transform.position = new Vector3(random, 6, 0);
        objetosDeDa�oActivo.Last.Value.gameObject.SetActive(true);
    }
    public void eliminar_da�o()
    {
        //objetosDeDa�o.AddLast(objetosDeDa�oActivo.First.Value.gameObject.gameObject.gameObject.gameObject);
        //objetosDeDa�oActivo.RemoveFirst();


        //Debug.Log(objetosDeDa�o.Count);
        
        
        LinkedListNode<GameObject> nodoATransferir = objetosDeDa�oActivo.First;
        objetosDeDa�o.AddLast(nodoATransferir.Value);
        objetosDeDa�oActivo.RemoveFirst();


        objetosDeDa�o.Last.Value.gameObject.SetActive(false);
    }






    void crear_Punto()
    {
        random = Random.Range(-10.6f, 10.6f);
        //objetosDeDa�oActivo.AddLast(objetosDeDa�o.First.Value.gameObject.gameObject);
        //objetosDeDa�o.RemoveFirst();

        LinkedListNode<GameObject> nodoATransferir = objetosDePunto.First;
        objetosDePuntoActivo.AddLast(nodoATransferir.Value);


        //Debug.Log(objetosDeDa�o.Count);


        objetosDeDa�o.RemoveFirst();

        objetosDePuntoActivo.Last.Value.gameObject.transform.position = new Vector3(random, 6, 0);
        objetosDePuntoActivo.Last.Value.gameObject.SetActive(true);
    }
    public void eliminar_punto()
    {
        //objetosDeDa�o.AddLast(objetosDeDa�oActivo.First.Value.gameObject.gameObject.gameObject.gameObject);
        //objetosDeDa�oActivo.RemoveFirst();


        //Debug.Log(objetosDeDa�o.Count);


        LinkedListNode<GameObject> nodoATransferir = objetosDePuntoActivo.First;
        objetosDePunto.AddLast(nodoATransferir.Value);
        objetosDePuntoActivo.RemoveFirst();


        objetosDePunto.Last.Value.gameObject.SetActive(false);
    }
}
