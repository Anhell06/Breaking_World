using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbstractBlock : MonoBehaviour
{
    [SerializeField]
    private bool isMovable;
    [SerializeField]
    private bool isDeathable;
    [SerializeField]
    private bool isDestroyable;
    [SerializeField]
    private ItemSO item;
    [SerializeField]
    private MoveFieldChanelSO mover;
    private Vector3 startPosition;
    private AbstractBlock ClashBlock;
    
    [SerializeField]
    private bool[] environmentBlocks;
    private Vector3[] direction;

    public bool IsDeathable { get => isDeathable; }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left), Color.green);
    }


    private void Start()
    {
        mover.TouchForMoveFildeUpdate += StartTouch;
        mover.TouchBeEnded += EndMove;

        startPosition = transform.position;
        environmentBlocks = new bool[4] { false, false, false, false };
        direction = new Vector3[4] { Vector3.forward, -Vector3.forward, Vector3.left, -Vector3.left };

        GetEnviropmentBlock();
    }

    private void GetEnviropmentBlock()
    {
        for (int i = 0; i < 4; i++)
        {
            Ray ray = new Ray(transform.position, direction[i]);

            if (Physics.Raycast(ray, out RaycastHit hit, 1f) && hit.transform.GetComponent<AbstractBlock>())
            {
                environmentBlocks[i] = true;
            }
            else
            {
                environmentBlocks[i] = false;
            }

        }
    }

    private void StartTouch(Vector2 vector)
    {
        if (isMovable)
        {
            Vector3 ver3 = Vector2ToVector3(vector);

            if (IsThereDirectionalBlock(ver3))
                return;

            
            if (transform.position.x >= startPosition.x + 0.5)
            {
                transform.position = startPosition;
            }
            if (transform.position.z >= startPosition.z + 0.5)
            {
                transform.position = startPosition;
            }
            if (transform.position.x <= startPosition.x - 0.5)
            {
                transform.position = startPosition;
            }
            if (transform.position.z <= startPosition.z - 0.5)
            {
                transform.position = startPosition;
            }

            transform.position += ver3 ;
        }

    }

    private static Vector3 Vector2ToVector3(Vector2 vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }

    private void OnDestroy()
    {
        mover.TouchForMoveFildeUpdate -= StartTouch;
        mover.TouchBeEnded -= EndMove;
    }
    private void EndMove(Vector2 vector)
    {
        if (isMovable)
        {
            Vector3 ver3 = Vector2ToVector3(vector);

            if (IsThereDirectionalBlock(ver3) == false)
                startPosition += ver3;

            transform.position = startPosition;
            
        }
        if (ClashBlock != null)
        {
            Destroy();
        }
        GetEnviropmentBlock();


    }
    public void Destroy()
    {
        if (isDestroyable)
        {
            Destroy(gameObject);
        }
    }
    public ItemSO GetItem()
    {
        if (item == null)
        {
            return null;
        }
        if (item.isUsable)
        {
            return item;
        }
        return null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AbstractBlock>())
        {
            ClashBlock = other.GetComponent<AbstractBlock>();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        ClashBlock = null;
    }
    public void ChangeTypeThisBlock(AbstractBlock BlockChange)
    {
        var block = gameObject.AddComponent<AbstractBlock>();
        block = BlockChange;
    }

    
    private bool IsThereDirectionalBlock(Vector3 moveDirection)
    {
        if (isDestroyable == false)
        {
            for (int i = 0; i < 4; i++)
            {

                if (Vector3.Dot(moveDirection, direction[i]) > 0.9 && environmentBlocks[i])
                {
                    transform.position = startPosition;
                    return true;
                }

            }
        }
        return false;

    }

}
