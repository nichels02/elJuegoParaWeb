using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador : MonoBehaviour
{
    [SerializeField] GameObject punto;
    [SerializeField] GameObject daño;
    [SerializeField] float time_daño;
    [SerializeField] float time_punto;
    [SerializeField] float periodo_daño=0.3f;
    [SerializeField] float periodo_punto=4;
    float time;
    float random;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        time_daño+=Time.deltaTime;
        time_punto+=Time.deltaTime;
        if (time > 10)
        {
            periodo_daño -= 0.01;
        }
        if (time_daño > 0.3)
        {
            random = Random.Range(-10.6f, 10.6f);
            Instantiate(daño, new Vector3(random, 6, 0), Quaternion.identity);
            time_daño = 0;
        }
        if (time_punto > 4)
        {
            random = Random.Range(-10.6f, 10.6f);
            print("hi");
            Instantiate(punto, new Vector3(random, 6, 0), Quaternion.identity);
            time_punto = 0;
        }
    }
}
