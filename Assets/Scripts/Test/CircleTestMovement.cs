using System.Collections;
using System.Collections.Generic;
using Map;
using UnityEngine;

namespace Test
{
    public class CircleTestMovement : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.transform.position += new Vector3(0.2f, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.position += new Vector3(-0.2f, 0f, 0f);
            }
        }
    }
}