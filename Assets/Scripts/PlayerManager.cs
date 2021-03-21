using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject playerHandArea;
    public GameObject faceDownPile;
    public GameObject discardPile;
    public GameObject goDownArea;

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

    public override void OnStartClient()
    {
        base.OnStartClient();
        playerHandArea = GameObject.Find("playerHandArea");
        faceDownPile = GameObject.Find("faceDownPile");
        discardPile = GameObject.Find("discardPile");
        goDownArea = GameObject.Find("goDownArea");
    }

    [Server]
    public override void OnStartServer()
    {
        cardList = new GameObject[118] { A, A, A, A, A, A, A, A, A, A, B, B, C, C, D, D, D, D, E, E, E, E, E, E, E, E, E, E, E, E, F, F, G, G, G, G, H, H, I, I, I, I, I, I, I, I, J, J, K, K, L, L, L, L, M, M, N, N, N, N, N, N, O, O, O, O, O, O, O, O, P, P, Q, Q, R, R, R, R, R, R, S, S, S, S, T, T, T, T, T, T, U, U, U, U, U, U, V, V, W, W, X, X, Y, Y, Y, Y, Z, Z, ER, ER, CL, CL, IN, IN, TH, TH, QU, QU };

    }

    [Command]
    public void CmdDealCards()
    {
        foreach (GameObject card in cardList)
        {
            cardDeck.Add(card);
        }

        //Shuffle the cards
        for (int i = 0; i < cardDeck.Count; i++)
        {
            int num1 = Random.Range(0, cardDeck.Count);
            int num2 = Random.Range(0, cardDeck.Count);
            GameObject card1 = cardDeck[num1], card2 = cardDeck[num2];

            cardDeck[num1] = card2;
            cardDeck[num2] = card1;
        }

        for (int i = 0; i < 118; i++)
        {
            GameObject currentCard = cardDeck[0];
            GameObject playerCard = Instantiate(currentCard, new Vector2(0, 0), Quaternion.identity);
            cardDeck.Remove(currentCard);

            NetworkServer.Spawn(playerCard, connectionToClient);

            playerCard.transform.SetParent(faceDownPile.transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
