using System;
using System.Collections.Generic;

[Serializable]
public class Level
{
    public int rowSize;

    public List<int> blocks;

    public Level(int rowSize, List<int> blocks)
    {
        this.rowSize = rowSize;
        this.blocks = blocks;
    }
}