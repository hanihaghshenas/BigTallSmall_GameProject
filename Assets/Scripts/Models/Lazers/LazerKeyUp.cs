using System;
using UnityEngine;

namespace Models.Lazers
{
    public class LazerKeyUp: MonoBehaviour
    {
        public LazerDoorController LazerDoorController;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("enter the collider");
            if (
                other.gameObject.CompareTag(TagsEnum.Character.ToString()) ||
                other.gameObject.CompareTag(TagsEnum.Tall.ToString()) ||
                other.gameObject.CompareTag(TagsEnum.Big.ToString()) ||
                other.gameObject.CompareTag(TagsEnum.Small.ToString())
                )
            {
                Debug.Log("Turn on");
                LazerDoorController.TurnOff();
            }            
            
            if (other.gameObject.CompareTag(TagsEnum.Box.ToString()))
            {
                Debug.Log("Turn on");
                LazerDoorController.TurnOff();
            }
        }

    }
    
    
}