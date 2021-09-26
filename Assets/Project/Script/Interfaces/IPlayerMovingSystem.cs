using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMovingSystem
{
    void Move();
    float GetSpeed { get; }
    float GetWaitingTime { get; }

}
