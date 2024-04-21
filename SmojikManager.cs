using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmojikManager : MonoBehaviour
{
    private Mover mov;

    private GameObject gobui;
    private GameObject crackers;
    private GameObject barbus;

    private GameObject player;
    private new GameObject camera;

    private int gob = 0;

    private void Awake()
    {
        //mov = GameObject.FindGameObjectWithTag("SharedPlayer")
        player = GameObject.FindGameObjectWithTag("SharedPlayer");
        mov = player.GetComponent<Mover>();

        gobui = GameObject.FindGameObjectWithTag("Gobui");
        crackers = GameObject.FindGameObjectWithTag("Crackers");
        barbus = GameObject.FindGameObjectWithTag("Barbus");

        camera = GameObject.FindGameObjectWithTag("MainCamera");

       /* DontDestroyOnLoad(mov);
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(camera);*/
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerChangeUp();
        }
    }

    void playerChangeUp()
    {
        if (gob == 0)
        {
            gobui.SetActive(false);
            crackers.SetActive(true);
            mov.characterSet(1);
            gob = 1;
        }
        else if (gob == 1)
        {
            crackers.SetActive(false);
            barbus.SetActive(true);
            mov.characterSet(2);
            gob = 2;
        }
        else if (gob == 2)
        {
            barbus.SetActive(false);
            gobui.SetActive(true);
            mov.characterSet(0);
            gob = 0;
        }
    }

}