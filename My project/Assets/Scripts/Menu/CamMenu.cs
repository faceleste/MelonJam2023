using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMenu : MonoBehaviour
{
    private Animator animCam; // for future animations
    public Transform player;
    public Transform player2;
    public Vector3 offset;
    [Range(0, 10)]
    public Vector3 positionAl;
    public float SmoothFactor;
    public Vector3 minValues, maxValues; 
    

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform; // find the obj "Player"
        
    }
    void FixedUpdate()
    {
        player.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positionAl = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Follow(); 
        
    }

    void Follow() // follow the positionAI
    {
        Vector3 targetPosition = positionAl + offset;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValues.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z)); // control the cam limits

        Vector3 SmoothPosition = Vector3.Lerp(transform.position, boundPosition, SmoothFactor*Time.fixedDeltaTime); 
        transform.position = SmoothPosition; // smoothes the cam move
        
    }
}
