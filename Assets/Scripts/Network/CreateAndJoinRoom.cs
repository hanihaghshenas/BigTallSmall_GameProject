using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public InputField joinInput;
    string myString;

    string RoomName;
    public Text RoomID;
    bool Joined = false;
    bool OnJoinedaRoom = false;

    private void Start()
    {
        Joined = false;
    }
    public void CreateRoom()
    {
        RoomOptions opts = new RoomOptions();
        opts.MaxPlayers = 3;
        RoomName = RandomStringGenerator();
        PhotonNetwork.CreateRoom( RoomName , opts);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
        OnJoinedaRoom = true;
        
    }
    public override void OnJoinedRoom()
    {
        Debug.Log(RoomName);
        RoomID.text = "Room ID - " + RoomName;
        Joined = true;
        if(OnJoinedaRoom == true)
        {
            StartClicked();
        }
    }
    public void StartClicked()
    {
        if (Joined == true)
        {
            PhotonNetwork.LoadLevel("Level03");
        }
    }
     public string RandomStringGenerator()
    {
        const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
        for (int i = 0; i < 6; i++)
        {
           myString += glyphs[Random.Range(0, glyphs.Length)];
        }
        return myString;
    }
}
