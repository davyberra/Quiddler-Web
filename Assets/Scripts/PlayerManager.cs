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

    public turnHandler turnHandler;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        turnHandler.playerCount += 1;
        playerNumber = turnHandler.playerCount;

        playerHandArea = GameObject.Find("playerHandArea");
        faceDownPile = GameObject.Find("faceDownPile");
        discardPile = GameObject.Find("discardPile");
        goDownArea = GameObject.Find("goDownArea");
        mainCanvas = GameObject.Find("Game Panel");


        //deckHandler.AssignAuthority(connectionToClient, cardList);


    }



}
