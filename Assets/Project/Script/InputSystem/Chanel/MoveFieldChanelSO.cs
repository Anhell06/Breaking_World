using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MoveFieldChanel", menuName = "ActionChanel/MoveFieldChanel", order = 51)]
public class MoveFieldChanelSO : ScriptableObject
{
    public UnityAction<Vector2> TouchForMoveFildeUpdate;
    public UnityAction<Vector2> TouchBeEnded;

    public void UpdateMovingMessage(Vector2 deltaTouch)
    {
        TouchForMoveFildeUpdate?.Invoke(deltaTouch);
    }
    public void EndMovingMessage(Vector2 deltaTouch)
    {
        TouchBeEnded?.Invoke(deltaTouch);
    }

}
