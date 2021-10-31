using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFieldBilder : MonoBehaviour, IFieldBilder
{
    [SerializeField]
    private List<AbstractBlock> blockPool;
    [SerializeField]
    private BorderBlock borderBlock;
    [SerializeField]
    private AbstractBlock startedBlock;
    [SerializeField]
    private List<ItemSO> itemPool;

    private int spawnPointX, spawnPointY;

    private Battlefield battlefield;

    public void AddItemOnField()
    {
        //for (int i = 0; i < itemPool.Count; i++)
        //{
        //    battlefield.line[RandomBattlefiedlOnWidth()].block[RandomBattelfieldOnHidth()].item = itemPool[i];
        //}
    }

    private int RandomBattelfieldOnHidth() =>
        battlefield.line[0].block.Length;

    private int RandomBattlefiedlOnWidth() =>
        battlefield.line.Length;


    public void CheckField()
    {
        //TODO: 
        //Отправить в словер на проверку
    }

    public void MakeField(int difficulty, Battlefield battlefield)
    {
        this.battlefield = battlefield;
        for (int i = 0; i < battlefield.line.Length; i++)
        {
            for (int j = 0; j < battlefield.line[0].block.Length; j++)
            {

                if (i == 0 || i == battlefield.line.Length - 1 || j == 0 || j == battlefield.line[0].block.Length - 1)
                {
                    battlefield.line[i].block[j] = borderBlock;
                }
                else
                {
                    battlefield.line[i].block[j] = blockPool[Random.Range(0, blockPool.Count)];
                }
            }
        }
        battlefield.line[3].block[battlefield.line[0].block.Length - 1] = startedBlock;
        battlefield.line[3].block[battlefield.line[0].block.Length - 2] = startedBlock;
    }

    public Battlefield GetField() =>
        battlefield;
}
