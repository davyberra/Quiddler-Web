using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public int playerNumber;

    public GameObject playerHandArea;
    public GameObject faceDownPile;
    public GameObject discardPile;
    public GameObject goDownArea;
    public GameObject mainCanvas;
    //public GameObject gameMenu;
    public PlayerManager playerManager;
    public DeckHandler deckHandler;
    List<GameObject> cardDeck;

    public turnHandler turnHandler;

    public void Awake()
    {

        //turnHandler.playerCount += 1;
        //playerNumber = turnHandler.playerCount;
        //gameObject.name = $"Player {playerNumber}";


        playerHandArea = GameObject.Find("playerHandArea");
        faceDownPile = GameObject.Find("faceDownPile");
        discardPile = GameObject.Find("discardPile");
        goDownArea = GameObject.Find("goDownArea");
        mainCanvas = GameObject.Find("Game Panel");
        deckHandler = faceDownPile.GetComponent<DeckHandler>();
        cardDeck = deckHandler.cardDeck;



        //deckHandler.AssignAuthority(connectionToClient, cardList);


    }

    public void DrawOnClick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerManager = networkIdentity.GetComponent<PlayerManager>();
        playerManager.CmdDealHand();
    }

    [Command]
    public void CmdDealHand()
    {
        
        for (int i = 0; i < turnHandler.cardCount; i++)
        {
            CardClass[] faceDownCards = faceDownPile.GetComponentsInChildren<CardClass>();
            CardClass playerCard = faceDownCards[0];
            playerCard.transform.SetParent(playerHandArea.transform, false);
            playerCard.transform.position = playerHandArea.transform.position;


        }
        

    }



}
