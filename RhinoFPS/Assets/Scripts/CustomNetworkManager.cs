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
            Debug.Log(p.gameObject.GetComponent<CharacterControl>().name + " joined");
            Players.Add(p.gameObject);
        }
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        foreach (PlayerController p in conn.playerControllers)
        {
            Debug.Log(p.gameObject.GetComponent<CharacterControl>().name + " left");
            Players.Remove(p.gameObject);
        }
    }

    public override void OnStartServer()
    {
        InvokeRepeating("PingServer", 1f, 3f);
    }

    void PingServer()
    {
        for (int i = 0; i < NetworkServer.connections.Count; ++i)
        {
            int rtt;
            NetworkConnection c = NetworkServer.connections[i];
            if (c == null)
            {
                continue;
            }
            byte error;
            if (c.hostId < 0)
            {
                rtt = 0;
            }
            else
            {
                rtt = NetworkTransport.GetCurrentRtt(c.hostId, c.connectionId, out error);
            }
            //Debug.Log(c.playerControllers[0].gameObject.GetComponent<CharacterControl>().NameText.text + " " + rtt);
        }
        //EmptyMessage msg = new EmptyMessage();420
        //NetworkServer.SendToAll(Score, msg);
        /*
        if (ServerIP != null && (serverPing.isDone || serverPing == null))
        {
            serverPing = new Ping(ServerIP);
        }
        */
    }
}
