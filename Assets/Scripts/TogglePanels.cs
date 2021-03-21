using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TogglePanels : NetworkBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public PlayerManager PlayerManager;

    public void OnClick()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
        PlayerManager.CmdDealCards();
    }
    
}
