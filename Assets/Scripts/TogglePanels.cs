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
        if (NetworkServer.connections.Count <= 2)
        {
            
            StartGameView();
            GameObject faceDownPile = GameObject.Find("faceDownPile");
            DeckHandler deckHandler = faceDownPile.GetComponent<DeckHandler>();
            deckHandler.PrepareDeck();
            deckHandler.DealHand();
            //NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            //PlayerManager = networkIdentity.GetComponent<PlayerManager>();
           
        }
    }

    [ClientRpc]
    public void StartGameView()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    
}
