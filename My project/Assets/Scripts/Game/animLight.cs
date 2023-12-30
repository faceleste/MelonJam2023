using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animLight : MonoBehaviour
{
    public GameObject luz;
    public float timeToPiscar;
    public float countPiscar;
    // Start is called before the first frame update
    void Start()
    {
        countPiscar = timeToPiscar;
        luz.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        countPiscar -= Time.deltaTime;
        if(countPiscar <= 0 && countPiscar > -2)
        {
            int i = Random.Range(1, 10);
            if(i >= 5)
            {
                luz.SetActive(true);
            }
        }
        if(countPiscar <= -1)
        {
            luz.SetActive(false);
            countPiscar = timeToPiscar;
        }
    }
}
