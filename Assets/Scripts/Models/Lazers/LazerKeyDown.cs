using UnityEngine;

namespace Models.Lazers
{
    public class LazerKeyDown : MonoBehaviour
    {
        public LazerDoorController LazerDoorController;

        private void OnCollisionExit2D(Collision2D other)
        {
            if (
                other.gameObject.CompareTag(TagsEnum.Character.ToString()) ||
                other.gameObject.CompareTag(TagsEnum.Tall.ToString()) ||
                other.gameObject.CompareTag(TagsEnum.Big.ToString()) ||
                other.gameObject.CompareTag(TagsEnum.Small.ToString())
            )
            {
                LazerDoorController.TurnOn();
            }

            if (other.gameObject.CompareTag(TagsEnum.Box.ToString()))
            {
                LazerDoorController.TurnOn();
            }
        }
    }
}