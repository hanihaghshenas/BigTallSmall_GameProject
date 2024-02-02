using System.Collections.Generic;

namespace Map
{

    [System.Serializable]
    public class BlockRow
    {
        public List<int> Blocks;
    }
    
    [System.Serializable]
    public class Map
    {
        public List<BlockRow> Rows;
    }
}