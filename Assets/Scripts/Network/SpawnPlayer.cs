using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject Big;
    public GameObject Tall;
    public GameObject Small;
    PlayerData playerData;
  
    float X , Y;
    
    void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        X = -5.27f;
        Y = 0.27f;

        Vector2 Position = new Vector2(X, Y);

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate(Big.name, Position, Quaternion.identity);
            playerData.SetPlayerInfo("Big" , 0);
        }
        if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.Instantiate(Tall.name, Position, Quaternion.identity);
           playerData.SetPlayerInfo("Tall" , 1);
        }
        if(PhotonNetwork.CurrentRoom.PlayerCount == 3)
        {
            PhotonNetwork.Instantiate(Small.name, Position, Quaternion.identity);
           playerData.SetPlayerInfo("Small" , 2);
        }
        
    }
   
   
}
