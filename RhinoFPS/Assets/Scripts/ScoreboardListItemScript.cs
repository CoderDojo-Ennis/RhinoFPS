using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ScoreboardListItemScript : ScoreboardContent
{
    public Text PlayerNameText;
    public Text LatencyText;
    public Text KillsText;
    public Text DeathsText;
    public CharacterControl Player;
	
    void Start()
    {
        //yerNameText.text = Player
        //LatencyText = Network.GetLastPing(Player);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
