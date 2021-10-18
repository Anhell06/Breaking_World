using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
    private RaycastHit hit;
    private Player player;

    void CheckemptyBlock()
    {
        //сам луч, начинается от позиции этого объекта и направлен в сторону цели
        Ray ray = new Ray(transform.position + Vector3.forward / 2, Vector3.down);
        //пускаем луч
        Physics.Raycast(ray, out hit);

        //если луч с чем-то пересёкся, то..
        if (hit.transform.GetComponent<AbstractBlock>() == true)
        {
        }
        else
        {
            player.Death();
        }

    }
    public void Start()
    {
        gameObject.GetComponent<Player>();
    }
}
