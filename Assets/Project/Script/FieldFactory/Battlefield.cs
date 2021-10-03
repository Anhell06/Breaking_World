using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Battlefield 
{
    public Line[] line;

    public void SetField(int width, int height)
    {
        line = new Line[width];
        for (int i = 0; i < line.Length; i++)
        {
            line[i].block = new AbstractBlock[height];
        }
    }
}


[System.Serializable]
public struct Line
{
    public AbstractBlock[] block;
}
