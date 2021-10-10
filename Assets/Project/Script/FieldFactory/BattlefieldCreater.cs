using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldCreater : MonoBehaviour
{
    [SerializeField]
    private IFieldBilder fieldBilder;
    [SerializeField]
    private Battlefield battlefield;
    [SerializeField]
    private int fieldWidth;
    [SerializeField]
    private int fieldHeight;

    private int difficulty;

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

        for (int i = 0; i < battlefield.line.Length; i++)
        {
            for (int j = 0; j < battlefield.line[0].block.Length; j++)
            {
                var block = battlefield.line[i].block[j];
                Instantiate(block, new Vector3(i, 0, j) + transform.position, Quaternion.identity, transform);
            }

        }
    }
}




