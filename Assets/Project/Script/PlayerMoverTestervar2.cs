using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverTestervar2 : MonoBehaviour, IPlayerMovingSystem
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float waitingTime;

    private bool isMoving = false;
    private Vector3 currentPosition;
    private const int Ofset = 1;

    public float GetSpeed => speed;

    public float GetWaitingTime => waitingTime;

    public void Move()
    {
        isMoving = true;
        Debug.Log("Проверка");
    }

    public void Start()
    {
        currentPosition = transform.position;
    }

    public void Update()
    {
        if (transform.position.z <= currentPosition.z - Ofset)
        {
            isMoving = false;
            currentPosition = transform.position;
        }

        if (isMoving == true)
        {
            transform.position += Time.deltaTime * speed * Vector3.forward;
        }
    }
}
