using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject playerHandArea;
    public GameObject faceDownPile;
    public GameObject discardPile;
    public GameObject goDownArea;
    public GameObject mainCanvas;
    //public GameObject gameMenu;

    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;
    public GameObject F;
    public GameObject G;
    public GameObject H;
    public GameObject I;
    public GameObject J;
    public GameObject K;
    public GameObject L;
    public GameObject M;
    public GameObject N;
    public GameObject O;
    public GameObject P;
    public GameObject Q;
    public GameObject R;
    public GameObject S;
    public GameObject T;
    public GameObject U;
    public GameObject V;
    public GameObject W;
    public GameObject X;
    public GameObject Y;
    public GameObject Z;
    public GameObject ER;
    public GameObject IN;
    public GameObject CL;
    public GameObject TH;
    public GameObject QU;
    public CardClass[] cardList;
    public List<CardClass> cardDeck = new List<CardClass>();

    public turnHandler turnHandler;

    public override void OnStartClient()
    {
        base.OnStartClient();
        playerHandArea = GameObject.Find("playerHandArea");
        faceDownPile = GameObject.Find("faceDownPile");
        discardPile = GameObject.Find("discardPile");
        goDownArea = GameObject.Find("goDownArea");
        mainCanvas = GameObject.Find("Main Canvas");
        cardList = faceDownPile.GetComponentsInChildren<CardClass>();
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        DeckHandler deckHandler = networkIdentity.GetComponent<DeckHandler>();
        deckHandler.AssignAuthority(connectionToClient);
        CmdDealHand();
        
    }

    [Command]
    void CmdDealHand()
    {
        if (hasAuthority)
        {
            DealHand();
        }
    }

    [TargetRpc]
    void DealHand()
    {
        for (int i = 0; i < turnHandler.cardCount; i++)
        {
            foreach (CardClass card in cardList)
            {
                cardDeck.Add(card);
                

            }
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            CardClass playerCard = cardDeck[cardDeck.Count - 1];
            playerCard.transform.SetParent(playerHandArea.transform, false);
            NetworkIdentity cardIdentity = playerCard.GetComponent<NetworkIdentity>();
            cardIdentity.AssignClientAuthority(connectionToClient);
            RpcShowCard(playerCard.transform, "dealHand");
        }
    }

    [ClientRpc]
    public void RpcShowCard(Transform card, string type)
    {
        if (!hasAuthority)
        {
            return;
        }
        if (type == "roundStart")
        {


            card.SetParent(faceDownPile.transform, false);

        }
        else if (type == "dealHand")
        {
            card.SetParent(playerHandArea.transform, false);
            card.position = playerHandArea.transform.position;
        }
    }

}
