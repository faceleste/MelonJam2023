using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desconfiometro : MonoBehaviour
{

    public float desconfiometro = 95;
    // Start is called before the first frame update
    void Start()
    {
        //setar valor do value do slider como desconfiometro
        GetComponent<UnityEngine.UI.Slider>().value = desconfiometro;
    }

    // Update is called once per frame
    void Update()
    {
        desconfiometro = GetComponent<UnityEngine.UI.Slider>().value;
    }
}
