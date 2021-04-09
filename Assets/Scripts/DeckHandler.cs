using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Mirror;

public class DeckHandler : NetworkBehaviour
{
    public GameObject faceDownPile;
    public GameObject mainCanvas;
    public GameObject discardPile;
    public GameObject playerHandArea;

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
    public GameObject[] cardList;
    public List<GameObject> cardDeck = new List<GameObject>();

    public turnHandler turnHandler;

    public void Awake()
    {      
        faceDownPile = GameObject.Find("faceDownPile");
        discardPile = GameObject.Find("discardPile");
        playerHandArea = GameObject.Find("playerHandArea");
        mainCanvas = GameObject.Find("Game Panel");
    }

    [Server]
    public void PrepareDeck()
    {
        cardList = new GameObject[118] { A, A, A, A, A, A, A, A, A, A, B, B, C, C, D, D, D, D, E, E, E, E, E, E, E, E, E, E, E, E, F, F, G, G, G, G, H, H, I, I, I, I, I, I, I, I, J, J, K, K, L, L, L, L, M, M, N, N, N, N, N, N, O, O, O, O, O, O, O, O, P, P, Q, Q, R, R, R, R, R, R, S, S, S, S, T, T, T, T, T, T, U, U, U, U, U, U, V, V, W, W, X, X, Y, Y, Y, Y, Z, Z, ER, ER, CL, CL, IN, IN, TH, TH, QU, QU };
        foreach (GameObject card in cardList)
        {
            cardDeck.Add(card);
        }

        //Shuffle the cards
        for (int i = 0; i < cardDeck.Count; i++)
        {
            int num1 = UnityEngine.Random.Range(0, cardDeck.Count);
            int num2 = UnityEngine.Random.Range(0, cardDeck.Count);
            GameObject card1 = cardDeck[num1], card2 = cardDeck[num2];

            cardDeck[num1] = card2;
            cardDeck[num2] = card1;
        }
        foreach (GameObject card in cardDeck)
        {
            GameObject currentCard = Instantiate(card, new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(currentCard, connectionToClient);
            currentCard.transform.SetParent(faceDownPile.transform, false);
            currentCard.transform.position = faceDownPile.transform.position;
            RpcShowCard(currentCard.transform, "roundStart");
        }
    }

    public void AssignAuthority(NetworkConnection conn, CardClass[] cardList)
    {
        
        foreach (CardClass card in cardList)
        {
            NetworkIdentity cardIdentity = card.GetComponent<NetworkIdentity>();
            cardIdentity.AssignClientAuthority(conn);
        }
    }

    [Command]
    void CmdDealHand()
    {
        if (hasAuthority)
        {
            DealHand();
        }
    }

    [Server]
    public void DealHand()
    {
        
        for (int i = 0; i < turnHandler.cardCount; i++)
        {
            CardClass[] faceDownCards = faceDownPile.GetComponentsInChildren<CardClass>();
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            CardClass playerCard = faceDownCards[0];
            playerCard.transform.SetParent(playerHandArea.transform, false);
            
            NetworkIdentity cardIdentity = playerCard.GetComponent<NetworkIdentity>();
            //cardIdentity.AssignClientAuthority(connectionToClient);
            ClientShowCard(playerCard.transform, "dealHand");
        }
    }

    [ClientRpc]
    public void ClientShowCard(Transform card, string type)
    {
        //if (!hasAuthority)
        //{
        //    return;
        //}
        if (type == "dealHand")
        {
            card.SetParent(playerHandArea.transform, false);
            card.position = playerHandArea.transform.position;
        }
    }

    [ClientRpc]
    public void RpcShowCard(Transform card, string type)
    {
        //if (!hasAuthority)
        //{
        //    return;
        //}
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
