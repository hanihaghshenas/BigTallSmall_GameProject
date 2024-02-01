using System;
using UnityEngine;

namespace Models.Players
{
    public abstract class AbstractPlayer : MonoBehaviour
    {
        public int keys = 0;
        public GameObject nearbyPickableItem = null;

        public abstract void PlayJumpSound();
        public abstract void PlayTerminationSound();
        
        public abstract void Jump();
        public abstract void Move();
    }
}