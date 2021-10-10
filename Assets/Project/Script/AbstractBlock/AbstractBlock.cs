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
    private Vector3 currentPosition;
    private AbstractBlock ClashBlock;

    public bool IsDeathable { get => isDeathable; }

    private void StartTouch(Vector2 vector)
    {
        if (isMovable)
        {
            Vector3 ver3 = Vector2ToVector3(vector);

            if (transform.position.x >= currentPosition.x + 0.5)
            {
                transform.position = currentPosition;
            }
            if (transform.position.z >= currentPosition.z + 0.5)
            {
                transform.position = currentPosition;
            }
            if (transform.position.x <= currentPosition.x - 0.5)
            {
                transform.position = currentPosition;
            }
            if (transform.position.z <= currentPosition.z - 0.5)
            {
                transform.position = currentPosition;
            }

            transform.position += ver3;
        }

    }

    private static Vector3 Vector2ToVector3(Vector2 vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }

    private void Start()
    {
        mover.TouchForMoveFildeUpdate += StartTouch;
        currentPosition = transform.position;
        mover.TouchBeEnded += EndMove;
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
            currentPosition += ver3;
            transform.position = currentPosition;
            //transform.position += ver3;
            //currentPosition = transform.position;

        }
        if (ClashBlock != null)
        {
            Destroy();
        }

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


    //TODO
    private void CheckBlokBeforeMove()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.position, out hit, 1))
        {
            return;
        }
    }

}
