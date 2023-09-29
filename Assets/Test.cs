using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject ObjetoA;
    [SerializeField] Vector2 pos = new Vector2(0,3.5f);
    [SerializeField] Quaternion rotacion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void crear_mensaje()
    {
        
        Instantiate(ObjetoA,pos,rotacion);
    }
}
