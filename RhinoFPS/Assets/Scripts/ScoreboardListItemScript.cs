using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ScoreboardListItemScript : MonoBehaviour
{
    public Text PlayerNameText;
    public Text LatencyText;
    public Text KillsText;
    public Text DeathsText;
    public CharacterControl Player;
	
	void Update ()
    {
        PlayerNameText.text = Player.name;
        LatencyText.text = Player.Latency.ToString();
        KillsText.text = Player.Kills.ToString();
        DeathsText.text = Player.Deaths.ToString();
    }
}
