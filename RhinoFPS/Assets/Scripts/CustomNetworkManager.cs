using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class CustomNetworkManager : NetworkManager
{
    public List<GameObject> Players = new List<GameObject>();
    public override void OnServerConnect(NetworkConnection conn)
    {
        foreach (PlayerController p in conn.playerControllers)
        {
            Players.Add(p.gameObject);
            Debug.Log("Player joined");
        }
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        foreach (PlayerController p in conn.playerControllers)
        {
            Players.Remove(p.gameObject);
            Debug.Log("Player left");
        }
    }
}
