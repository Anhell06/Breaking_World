using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFieldBilder
{
    Battlefield GetField();
    void CheckField();
    void AddItemOnField();
    void MakeField(int difficulty, Battlefield battlefield);
}
