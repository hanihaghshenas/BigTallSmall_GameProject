using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public Sprite[] PlayerImage;

    public Text Name;
    public Image image;

    public void SetPlayerInfo(string name , int PlayerNum)
    {
        Name.text = name;
        image.sprite = PlayerImage[PlayerNum];
    }
}
