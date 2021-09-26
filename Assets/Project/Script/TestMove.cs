using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public MoveFieldChanelSO so;
    void Start()
    {
        so.TouchForMoveFildeUpdate += upd;
        so.TouchBeEnded += ended;
    }

    private void ended(Vector2 arg0)
    {
        Debug.LogError("move ended " + arg0);
    }

    private void upd(Vector2 arg0)
    {
        Debug.LogError("move update " + arg0);
    }

    private void OnDestroy()
    {
        so.TouchForMoveFildeUpdate -= upd;
        so.TouchBeEnded -= ended;
    }

}
