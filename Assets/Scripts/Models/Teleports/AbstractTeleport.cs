using System;
using UnityEngine;

namespace Models.Teleports
{
    public abstract class AbstractTeleport : MonoBehaviour
    {
        public abstract bool CanTeleport();

        public void TransferPlayer()
        {
            
        }
    }
}