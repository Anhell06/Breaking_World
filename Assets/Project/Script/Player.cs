using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityAction<PlayerStatus> StatusChanged;

    private List<ItemSO> items;
    private IPlayerMovingSystem playerMover;
    private PlayerStatus status;
    private float waitingTime;

    private void Start()
    {
        playerMover = GetComponent<IPlayerMovingSystem>();
        waitingTime = playerMover.GetWaitingTime;
    }

    private void Update()
    {
        waitingTime -= Time.deltaTime;
        if (waitingTime <= 0)
        {
            MovePlayer();
            
        }
    }

    private void MovePlayer()
    {
        status = PlayerStatus.Move;
        StatusChanged?.Invoke(status);

        playerMover.Move();
        waitingTime = playerMover.GetWaitingTime;
        Debug.Log("PlayerMove");
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
        #region Блок
        var someBlock = other.GetComponent<AbstractBlock>();

        if (someBlock != null)
        {
            if (someBlock.IsDeathable)
            {
                Death();
            }
        }
        #endregion

        #region Конец уровня
        var endLevelTrigger = other.GetComponent<EndLevelTriggerEmpty>();

        if (endLevelTrigger != null)
        {
            LevelEnded();
        }
        #endregion

        //#region Предмет (не дописан)
        //var tryGetSomeItem = other.TGetComponent<AbstractBlock>();

        //if (tryGetSomeItem != null)
        //{
        //    if ()
             
        //}
        //#endregion

    }



}
