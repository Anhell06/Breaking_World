using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour, IPlayerMovingSystem
{
    private const int OFFCET = 1;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float waitingTime;

    private bool isMoving = false;
    private Vector3 currentPosition;
    private float currentTime;
    private Player player;

    public float GetSpeed => speed;

    public float GetWaitingTime => waitingTime;

    public void Start()
    {
        player = GetComponent<Player>();
        currentPosition = transform.position;
        currentTime = waitingTime;
    }


    public void Update()
    {
        waitingTime -= Time.deltaTime;
        if (waitingTime <= 0)
        {
            player.MovePlayer();
            Move();
        }

        if (transform.position.z <= currentPosition.z - OFFCET)
        {
            isMoving = false;
            currentPosition = transform.position;
        }

        if (isMoving == true)
        {
            transform.position += Time.deltaTime * speed * Vector3.forward;
        }
    }
    public void Move()
    {
        isMoving = true;
        waitingTime = currentTime;
        Debug.Log("Move");
    }

    public void SetWaitingTime(float newWaitingTime)
    {
        if (newWaitingTime > 0 || newWaitingTime < waitingTime)
        {
            waitingTime = newWaitingTime;
        }
    }
}
