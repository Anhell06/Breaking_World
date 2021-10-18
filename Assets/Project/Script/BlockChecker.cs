using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
    private RaycastHit hit;
    private Player player;

    void CheckemptyBlock()
    {
        //��� ���, ���������� �� ������� ����� ������� � ��������� � ������� ����
        Ray ray = new Ray(transform.position + Vector3.forward / 2, Vector3.down);
        //������� ���
        Physics.Raycast(ray, out hit);

        //���� ��� � ���-�� ��������, ��..
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
