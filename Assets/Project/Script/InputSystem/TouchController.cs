using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Camera))]
public class TouchController : MonoBehaviour
{
    [SerializeField]
    private float delayTime = .1f;
    [SerializeField, Range(0f, 1f)]
    private float directionThreshold = .9f;
    
    private InputController inputController;
    private Vector2 currentTouchPosition;
    private Vector2 startPosition;
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

    private void Update()
    {
        if (isTouch == false)
            return;

        timeAfterStartTouch += Time.deltaTime;

        if (timeAfterStartTouch < delayTime)
            return;
        
        currentTouchPosition = inputController.Generic.TouchPosition.ReadValue<Vector2>();
        SwipeDirectionUpdate(); 
    }

    private void Start()
    {
        inputController.Generic.StartContact.started += ctx => TouchStarted(ctx);
        inputController.Generic.StartContact.canceled += ctx => TouchEnded(ctx);
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

    }

    private void SwipeDirectionUpdate()
    {
        Vector2 directition = currentTouchPosition - startPosition;
        var directionNormolize = directition.normalized;

       
        if (Vector2.Dot(Vector2.up, directionNormolize) > directionThreshold)
        {
            //Debug.Log("Swipe UP");
        }
        if (Vector2.Dot(Vector2.down, directionNormolize) > directionThreshold)
        {
            //Debug.Log("Swipe down");
        }
        if (Vector2.Dot(Vector2.left, directionNormolize) > directionThreshold)
        {
            //Debug.Log("Swipe left");
        }
        if (Vector2.Dot(Vector2.right, directionNormolize) > directionThreshold)
        {
            //Debug.Log("Swipe right");
        }

    }
}


