using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Animator anim;
    public bool isP1;
    public Image imgP1;
    public bool isP2;
    public Image imgP2;

    public Cam camera;
    public float startCameraPosition;
    public float newOffset;
    // Start is called before the first frame update
    void Start()
    {
        startCameraPosition = camera.offset.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Change"))
        {
            anim.SetTrigger("isChange");
            if(isP1 == true)
            {
                camera.offset.x = newOffset;
                imgP1.enabled = true;
                imgP2.enabled = false;
                isP1 = false;
                isP2 = true;
            }
            else if(isP2 == true)
            {
                camera.offset.x = startCameraPosition;
                imgP1.enabled = false;
                imgP2.enabled = true;
                isP1 = true;
                isP2 = false;
            }
            
        }
        
        
    }
}
