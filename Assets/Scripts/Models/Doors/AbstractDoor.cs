using UnityEngine;

namespace Models.Doors
{
    public abstract class AbstractDoor : MonoBehaviour
    {
        public abstract void PlayOpeningDoorSound();
        public abstract bool CanItBeOpened();
    }
}