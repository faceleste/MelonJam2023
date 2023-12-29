using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Animator animCam; // for future animations
    public Transform player;
    public Transform playerAgain;
    public Vector3 offset;
    [Range(0, 10)]
    public Vector3 positionAl;
    public float SmoothFactor;
    public Vector3 minValues, maxValues; 
    public Camera camera;
    

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform; // find the obj "Player"
        camera.aspect = 1.5f;
    }
    void FixedUpdate()
    {
        positionAl = player.transform.position; // turn the player position to positionAI   
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
