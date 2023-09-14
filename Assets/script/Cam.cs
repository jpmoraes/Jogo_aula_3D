using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform cp1;
    public Transform cp3;
    private int video;
    public bool travarMouse = true;
    public float sensibilidade = 2.0f;
    private float mouseX, mouseY;
    public GameObject player;
  
    void Start()
    {
        video = 1;
        transform.position = cp3.position;

        if (!travarMouse){

            return;
        }

       Cursor.visible = false;
       Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
       

        if (Input.GetKeyUp(KeyCode.E)) { 

            if (video == 1)
            {
                transform.position = cp1.position;
                video = 3;
            }else if (video == 3)
            {
                transform.position = cp3.position;
                video = 1;
            }
        }

        mouseY += Input.GetAxis("Mouse Y") * sensibilidade;
        mouseX += Input.GetAxis("Mouse X") * sensibilidade;

        //player.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
       //transform.eulerAngles = new Vector3(mouseY, mouseX, 0);

    }
}



