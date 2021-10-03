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
   
    private void StartTouch(Vector2 vector)
    {
        if (isMovable)
        {
            Vector3 ver3 = new Vector3(vector.x, vector.y, 0);

            transform.position += ver3;
        }

    }
  
    public void Start()
    {
        mover.TouchForMoveFildeUpdate += StartTouch;

    }
    public void OnDestroy()
    {
        mover.TouchForMoveFildeUpdate -= StartTouch;
    }
}
