using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;

public class NewTestScript
{
    //private Vector2 resultVector;

    //[UnityTest]
    //public IEnumerator NewTestScriptWithEnumeratorPasses()
    //{
    //    Debug.Log(1);
    //    GameObject gameObject = GameObject.Instantiate(Resources.Load<GameObject>("TouchController Variant"));
    //    GameObject camera = GameObject.Instantiate(Resources.Load<GameObject>("Camera"));
    //    TouchController touchController = gameObject.GetComponent<TouchController>();
    //    Debug.Log(2);
    //    Debug.Log(touchController.name);

    //    MoveFieldChanelSO chanel = ScriptableObject.Instantiate(Resources.Load<MoveFieldChanelSO>("testChanel"));
    //    Debug.Log(3);
    //    Debug.Log(chanel.name);


    //    chanel.TouchForMoveFildeUpdate += direction =>  Debug.Log(direction);
    //    Debug.Log(5);
    //    touchController.UpdateSwipeDirection(Vector2.up, Vector2.zero);
    //    yield return new WaitForSeconds(20f);
    //    chanel.TouchForMoveFildeUpdate -= updateData;

    //    void updateData(Vector2 deriction)
    //    {
    //        Debug.Log(4);
    //        resultVector = Vector2.up;
    //        Debug.Log(deriction);
    //    }

    //    Assert.AreEqual(resultVector, Vector2.up);
    //}

    
}
