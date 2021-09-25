using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Item", menuName ="Item/defult_item",order =51)]
public class ItemSO : ScriptableObject
{
   public string name;
   public bool isUsable;
   public GameObject model;
        
}
