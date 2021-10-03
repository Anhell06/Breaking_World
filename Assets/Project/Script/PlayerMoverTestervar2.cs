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
    private Vector3 ofset = Vector3.forward;

    public float GetSpeed => speed;

    public float GetWaitingTime => waitingTime;

    public void Move()
    {
        isMoving = true;
    }

    public void Start()
    {
        currentPosition = transform.position;
    }

    public void Update()
    {
        transform.position += Time.deltaTime * speed * Vector3.forward;

        if (transform.position == currentPosition + ofset)
        {
            isMoving = false;
            currentPosition = transform.position;
        }
    }
}
