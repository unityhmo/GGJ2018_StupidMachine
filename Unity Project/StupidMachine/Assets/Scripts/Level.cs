using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level
{
    public int rowSize;

    public List<int> blocks;

    public Vector2 offset;

    public Level(int rowSize, List<int> blocks)
    {
        this.rowSize = rowSize;
        this.blocks = blocks;
    }

    public Level(int rowSize, List<int> blocks, Vector2 offset)
    {
        this.rowSize = rowSize;
        this.blocks = blocks;
        this.offset = offset;
    }
}