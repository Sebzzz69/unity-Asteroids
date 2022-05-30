using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public Player playerPrefab;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Player player = Instantiate(this.playerPrefab, this.transform.position, this.transform.rotation);
    }
}
