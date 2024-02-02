using System;
using System.Collections;
using System.Collections.Generic;
using Models.Lazers;
using Photon.Pun;
using UnityEngine;

public class LazerDoorController : MonoBehaviour
{
    public Lazer Lazer;
    public LazerKeyUp LazerKeyUp;
    public LazerKeyDown LazerKeyDown;

    // Start is called before the first frame update
    void Start()
    {
        Lazer.gameObject.SetActive(true);
        LazerKeyUp.gameObject.SetActive(true);
        LazerKeyDown.gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        Lazer.gameObject.SetActive(true);
        LazerKeyUp.gameObject.SetActive(true);
        LazerKeyDown.gameObject.SetActive(false);  
    }

    public void TurnOff()
    {
        Lazer.gameObject.SetActive(false);
        LazerKeyUp.gameObject.SetActive(false);
        LazerKeyDown.gameObject.SetActive(true);
    }
}
