using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Battlefield 
{
    public Line[] line;
    private const int OFFSET = 2;

    public void SetField(int width, int height)
    {
        line = new Line[width + OFFSET];
        for (int i = 0; i < line.Length; i++)
        {
            line[i].block = new AbstractBlock[height + OFFSET];
        }
    }
}


[System.Serializable]
public struct Line
{
    public AbstractBlock[] block;
}
