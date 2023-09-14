using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{

    public Image life; //Pego componente Image da Unity
    public Sprite image0;
    public Sprite image25;
    public Sprite image50;
    public Sprite image75;
    public Sprite image100; 
    public GameObject player; //Pega o player
    private bool gerarImage; //variavel de controle
    public Text text; //Pego componente Text da Unity

    void Start()
    {
        life.sprite = image100;
        gerarImage = false;
        text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

        if (player.GetComponent<MovePlayer>().life == 100 && gerarImage == true)
        {
            StartCoroutine(WaitImage(0.5f)); 

        }
        else if (player.GetComponent<MovePlayer>().life == 75)
        {
            life.sprite = image75;
        }
        else if (player.GetComponent<MovePlayer>().life == 50)
        {
            life.sprite = image50;
        }
        else if (player.GetComponent<MovePlayer>().life == 25)
        {

            life.sprite = image25;
            gerarImage = true;
        }
       


        text.text = Convert.ToString( player.GetComponent<MovePlayer>().moeda);

    }


    private IEnumerator WaitImage(float waitTime)
    {
        life.sprite = image0;
        yield return new WaitForSeconds(waitTime); 
        life.sprite = image100;
        gerarImage = false;
    }
}