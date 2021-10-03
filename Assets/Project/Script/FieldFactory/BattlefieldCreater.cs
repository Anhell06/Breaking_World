using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldCreater : MonoBehaviour
{
    [SerializeField]
    private IFieldBilder fieldBilder;
    [SerializeField]
    private Battlefield battlefield;
    private int difficulty;
    [SerializeField]
    private int fieldWidth;
    [SerializeField]
    private int fieldHeight;


    private void Start()
    {
        fieldBilder = GetComponent<IFieldBilder>();
        CreateField();
    }

    private void CreateField()
    {
        battlefield.SetField(fieldWidth, fieldHeight);

        fieldBilder.MakeField(difficulty, battlefield);
        fieldBilder.AddItemOnField();
        fieldBilder.CheckField();

        battlefield = fieldBilder.GetField();

        for (int i = 0; i < fieldWidth; i++)
        {
            for (int j = 0; j < fieldHeight; j++)
            {
                var block = battlefield.line[i].block[j];
                Instantiate(block, new Vector3(i, 0, j), Quaternion.identity);
            }

        }
    }
}




