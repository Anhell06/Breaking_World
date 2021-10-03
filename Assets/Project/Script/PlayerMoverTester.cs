using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverTester : MonoBehaviour, IPlayerMovingSystem
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float waitingTime;

    public float GetSpeed => speed;

    public float GetWaitingTime => waitingTime;

    public void Move()
    {
        transform.position += Vector3.forward * speed;
    }

}


