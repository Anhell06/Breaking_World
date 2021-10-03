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
    }
    private void Death()
    {
        status = PlayerStatus.Death;
        StatusChanged?.Invoke(status);
    }

    private void TryTakeItem()
    {
        status = PlayerStatus.Stay;
        StatusChanged?.Invoke(status);
    }

    private void LevelEnded()
    {
        status = PlayerStatus.Win;
        StatusChanged?.Invoke(status);
    }

    public void OnTriggerEnter(Collider other)
    {

    }


}
