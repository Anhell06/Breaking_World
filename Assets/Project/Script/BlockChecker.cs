using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
    private RaycastHit hit;
    private Player player;

    public void OnTriggerExit(Collider other)
    {
        CheckEmptyBlock();
    }
    void CheckEmptyBlock()
    { RaycastHit[] hits;
        
        Vector3 startRayPosition = new Vector3();
        startRayPosition = transform.position - Vector3.forward/2 + Vector3.up;

        Ray ray = new Ray(startRayPosition, Vector3.down*3);
      
        hits = Physics.RaycastAll(ray);
        
        Debug.DrawRay(startRayPosition, Vector3.down*3, Color.blue,2f);

        foreach (var hit in hits)
        {
            Debug.Log(hit.transform.name);
        }

        if (hits.Length == 0)
        {
            player.Death();
        }
    }
    public void Start()
    {
        player = gameObject.GetComponent<Player>();
    }
}
