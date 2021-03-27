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

    public void Awake()
    {

        if (isClient)
        {
            turnHandler.playerCount += 1;
            playerNumber = turnHandler.playerCount;
            gameObject.name = $"Player {playerNumber}";


            playerHandArea = GameObject.Find("playerHandArea");
            faceDownPile = GameObject.Find("faceDownPile");
            discardPile = GameObject.Find("discardPile");
            goDownArea = GameObject.Find("goDownArea");
            mainCanvas = GameObject.Find("Game Panel");
        }

        //deckHandler.AssignAuthority(connectionToClient, cardList);


    }



}
