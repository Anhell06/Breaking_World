using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//ƒобавить об€зательную проверку на наличии компонента IPlayerMovingSystem
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
        //установить стартовый статус игрока
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
        status = PlayerStatus.Move; //создать метод SetStatus(PlayerStatus status) и вынести в него эту и следующую строку
        StatusChanged?.Invoke(status);

        playerMover.Move();
        waitingTime = playerMover.GetWaitingTime; //вынести в апдейт под MovePlayer нарушает принцип единой ответственности
        Debug.Log("PlayerMove");
    }
    private void Death()
    {
        status = PlayerStatus.Death; // соответсвуенно оже заменетьс€ на метод SetStatus(PlayerStatus status)
        StatusChanged?.Invoke(status);
        Debug.Log("Death");
    }

    private void TryTakeItem()
    {
        status = PlayerStatus.Stay; // аналогично
        StatusChanged?.Invoke(status);
        Debug.Log("TryTakeItem");
    }

    private void LevelEnded()
    {
        status = PlayerStatus.Win; //тоже
        StatusChanged?.Invoke(status);
        Debug.Log("LevelEnded");
    }

    public void OnTriggerEnter(Collider other)
    {
        #region Ѕлок        
        // не исользуй регионы, если хочешь гдето воткнуть регион вынеси это лучше в отдельный метот типа CheckDethBlock()
        var someBlock = other.GetComponent<AbstractBlock>();

        if (someBlock != null)
        {
            if (someBlock.IsDeathable)
            {
                Death();
            }
        }
        #endregion

        #region  онец уровн€
        var endLevelTrigger = other.GetComponent<EndLevelTriggerEmpty>();

        if (endLevelTrigger != null)
        {
            LevelEnded();
        }
        #endregion // допиши вынеси в отдельный метот убери регион

        //#region ѕредмет (не дописан)
        //var tryGetSomeItem = other.TGetComponent<AbstractBlock>();

        //if (tryGetSomeItem != null)
        //{
        //    if ()
             
        //}
        //#endregion

    }



}
