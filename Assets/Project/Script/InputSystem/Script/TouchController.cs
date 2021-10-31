using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;


public class TouchController : MonoBehaviour
{
    [SerializeField, Header("Message Chanel")]
    private MoveFieldChanelSO moveMessageChanel;

    [SerializeField, Header("Params")]
    private float delayTime = .1f;
    [SerializeField, Range(0f, 1f)]
    private float directionThreshold = .9f;

    private InputController inputController;
    private Vector2 currentTouchPosition;
    private Vector2 startPosition = Vector2.zero;
    private Vector2 lastDirection = Vector2.zero;
    private bool isTouch = false;
    private float timeAfterStartTouch = 0;

    private void Awake()
    {
        inputController = new InputController();
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }
    private void Start()
    {
        inputController.Generic.StartContact.started += ctx => TouchStarted(ctx);
        inputController.Generic.StartContact.canceled += ctx => TouchEnded(ctx);
    }

    private void Update()
    {
        if (isTouch == false)
            return;

        timeAfterStartTouch += Time.deltaTime;

        if (timeAfterStartTouch < delayTime)
            return;

        currentTouchPosition = inputController.Generic.TouchPosition.ReadValue<Vector2>();
        UpdateSwipeDirection(currentTouchPosition, startPosition);
    }


    private void TouchStarted(CallbackContext ctx)
    {
        isTouch = true;
        startPosition = inputController.Generic.TouchPosition.ReadValue<Vector2>();
    }

    private void TouchEnded(CallbackContext ctx)
    {
        isTouch = false;
        timeAfterStartTouch = 0;
        moveMessageChanel.EndMovingMessage(lastDirection);
        lastDirection = Vector2.zero;
    }

    public void UpdateSwipeDirection(Vector2 currentTouchPosition, Vector2 startPosition)
    {
        Vector2 directition = currentTouchPosition - startPosition;
        var directionNormolize = directition.normalized;

        Vector2[] typeOfVectors = new Vector2[4] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        foreach (var vector in typeOfVectors)
        {
            if (Vector2.Dot(vector, directionNormolize) > directionThreshold)
            {
                SendMessageForMovingFild(vector);
            }
        }
    }

    private void SendMessageForMovingFild(Vector2 vector)
    {
        lastDirection = vector;
        moveMessageChanel.UpdateMovingMessage(vector);
    }
}


