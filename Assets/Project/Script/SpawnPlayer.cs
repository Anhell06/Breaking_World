using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private Player player;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private void Start()
    {
        Instantiate(player, spawnPoint);
    }
}
