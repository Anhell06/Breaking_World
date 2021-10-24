using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityAction<PlayerStatus> StatusChanged;

    private List<ItemSO> items;
    private PlayerStatus status;

    public void MovePlayer()
    {
        status = PlayerStatus.Move; 
        StatusChanged?.Invoke(status);
    }
    private void Death()
    {
        status = PlayerStatus.Death;
        StatusChanged?.Invoke(status);
        Debug.Log("Death");
    }

    private void TryTakeItem()
    {
        status = PlayerStatus.Stay;
        StatusChanged?.Invoke(status);
        Debug.Log("TryTakeItem");
    }

    private void LevelEnded()
    {
        status = PlayerStatus.Win;
        StatusChanged?.Invoke(status);
        Debug.Log("LevelEnded");
    }

    public void OnTriggerEnter(Collider other)
    {
        var someBlock = other.GetComponent<AbstractBlock>();

        if (someBlock != null)
        {

            if (someBlock.IsDeathable)
            {
                Death();
            }

            someBlock.GetItem();

            if (someBlock.GetItem() != null)
            {
                TryTakeItem();
            }

        }
        
        var endLevelTrigger = other.GetComponent<EndLevelTriggerEmpty>();

        if (endLevelTrigger != null)
        {
            LevelEnded();
        }
    }



}
