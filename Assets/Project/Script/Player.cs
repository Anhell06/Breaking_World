using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

//�������� ������������ �������� �� ������� ���������� IPlayerMovingSystem
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
        //���������� ��������� ������ ������
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
        status = PlayerStatus.Move; //������� ����� SetStatus(PlayerStatus status) � ������� � ���� ��� � ��������� ������
        StatusChanged?.Invoke(status);

        playerMover.Move();
        waitingTime = playerMover.GetWaitingTime; //������� � ������ ��� MovePlayer �������� ������� ������ ���������������
        Debug.Log("PlayerMove");
    }
    private void Death()
    {
        status = PlayerStatus.Death; // �������������� ��� ���������� �� ����� SetStatus(PlayerStatus status)
        StatusChanged?.Invoke(status);
        Debug.Log("Death");
    }

    private void TryTakeItem()
    {
        status = PlayerStatus.Stay; // ����������
        StatusChanged?.Invoke(status);
        Debug.Log("TryTakeItem");
    }

    private void LevelEnded()
    {
        status = PlayerStatus.Win; //����
        StatusChanged?.Invoke(status);
        Debug.Log("LevelEnded");
    }

    public void OnTriggerEnter(Collider other)
    {
        #region ����        
        // �� �������� �������, ���� ������ ����� �������� ������ ������ ��� ����� � ��������� ����� ���� CheckDethBlock()
        var someBlock = other.GetComponent<AbstractBlock>();

        if (someBlock != null)
        {
            if (someBlock.IsDeathable)
            {
                Death();
            }
        }
        #endregion

        #region ����� ������
        var endLevelTrigger = other.GetComponent<EndLevelTriggerEmpty>();

        if (endLevelTrigger != null)
        {
            LevelEnded();
        }
        #endregion // ������ ������ � ��������� ����� ����� ������

        //#region ������� (�� �������)
        //var tryGetSomeItem = other.TGetComponent<AbstractBlock>();

        //if (tryGetSomeItem != null)
        //{
        //    if ()
             
        //}
        //#endregion

    }



}
