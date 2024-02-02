using System;
using System.IO;
using UnityEngine;


namespace Map
{
    /*
     * Loads and render different kinds of maps
     */
    public class MapRenderer : MonoBehaviour
    {
        private const float Ratio = (float) 4 / 3;
        private const int VerticalBoxes = 18;
        private const int HorizontalBoxes = 24;

        public GameObject Block;
        public GameObject Background1;
        public GameObject Background2;


        void Start()
        {
            RenderMap("level_001");
        }

        public void RenderMap(string mapName)
        {
            var mapData = ReadJsonFile(mapName);


            Debug.Log("going to instantiate blocks");
            for (var i = 0; i < 24; i++)
            {
                for (var j = 0; j < 18; j++)
                {
                    GameObject go;
                    switch (mapData.Rows[j].Blocks[i])
                    {
                        // It is an empty cell
                        case 0:
                            go = Instantiate((i + j) %2 == 0 ? Background1 : Background2);
                            break;
                        // It is a wall cell
                        case 1:
                            go = Instantiate(Block);
                            break;
                        default:
                            continue;
                    }
                    
                    // For now I just hardcode the numbers
                    // Numbers -6.381f, 4.722f represents the top left point of screen
                    // (10/VerticalBoxes) = 0.555 and ((10) * Ratio)/HorizontalBoxes
                    go.transform.position =
                        new Vector3(-6.381f + i * 0.555f, 4.722f - j * 0.5555f, transform.position.z);
                }
            }
        }

        private Map ReadJsonFile(string mapName)
        {
            //var path = Application.dataPath + "/Maps/" + mapName + ".json";
            //var jsonString = File.ReadAllText(path);
            var text = Resources.Load<TextAsset>("Maps/" + mapName).ToString();
            return JsonUtility.FromJson<Map>(text);
        }
    }
}