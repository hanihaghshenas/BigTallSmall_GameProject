using UnityEngine;

namespace UI.Buttons
{
    public abstract class AbstractButton : MonoBehaviour
    {
        public abstract void PlayButtonSound();
        public abstract void OnButtonPressed();
    }
}