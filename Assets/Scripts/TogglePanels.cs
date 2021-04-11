using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TogglePanels : NetworkBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public PlayerManager playerManager;

    public void OnClick()
    {
        
            
        StartGameView();
        GameObject faceDownPile = GameObject.Find("faceDownPile");
        DeckHandler deckHandler = faceDownPile.GetComponent<DeckHandler>();
        if (isServer)
        {
            deckHandler.PrepareDeck();
            
        }
        

        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerManager = networkIdentity.GetComponent<PlayerManager>();
        //playerManager.CmdDealHand();   
        
    }

    [Client]
    public void DrawOnClick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerManager = networkIdentity.GetComponent<PlayerManager>();
        playerManager.CmdDealHand();
    }

    [Client]
    public void StartGameView()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    
}
