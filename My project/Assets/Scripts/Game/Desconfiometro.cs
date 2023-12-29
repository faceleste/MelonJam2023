using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desconfiometro : MonoBehaviour
{

    public float desconfiometro = 35;
    // Start is called before the first frame update
    void Start()
    {
      
        GetComponent<UnityEngine.UI.Slider>().value = desconfiometro;
    }

    // Update is called once per frame
    void Update()
    {
          GetComponent<UnityEngine.UI.Slider>().value = desconfiometro;
    }


}
