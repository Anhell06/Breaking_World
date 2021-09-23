using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="MoveFieldChanel", menuName = "ActionChanel/MoveFieldChanel", order = 51)]
public class MoveFieldChanelSO : ScriptableObject
{
    public UnityAction<Vector2> TouchStarted;
    public UnityAction<Vector2> TouchEnded;

    public void StartMovingMessage(Vector2 deltaTouch)
    {
        TouchStarted?.Invoke(deltaTouch);
    }
    public void EndMovingMessage(Vector2 deltaTouch)
    {
        TouchEnded?.Invoke(deltaTouch);
    }

}
