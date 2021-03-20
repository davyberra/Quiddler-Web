using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int round = 1;
    public static int cardsForRound = 3;

    public GameObject Card;
    public GameObject CardA;
    public GameObject playerHandArea;
    public GameObject faceDownPile;
    public GameObject discardPile;
    public GameObject goDownArea;

    public static GameObject A;
    public static GameObject B;
    public static GameObject C;
    public static GameObject D;
    public static GameObject E;
    public static GameObject F;
    public static GameObject G;
    public static GameObject H;
    public static GameObject I;
    public static GameObject J;
    public static GameObject K;
    public static GameObject L;
    public static GameObject M;
    public static GameObject N;
    public static GameObject O;
    public static GameObject P;
    public static GameObject Q;
    public static GameObject R;
    public static GameObject S;
    public static GameObject T;
    public static GameObject U;
    public static GameObject V;
    public static GameObject W;
    public static GameObject X;
    public static GameObject Y;
    public static GameObject Z;
    public static GameObject ER;
    public static GameObject IN;
    public static GameObject CL;
    public static GameObject TH;
    public static GameObject QU;
    public static GameObject[] cardList = new GameObject[118] { A, A, A, A, A, A, A, A, A, A, B, B, C, C, D, D, D, D, E, E, E, E, E, E, E, E, E, E, E, E, F, F, G, G, G, G, H, H, I, I, I, I, I, I, I, I, J, J, K, K, L, L, L, L, M, M, N, N, N, N, N, N, O, O, O, O, O, O, O, O, P, P, Q, Q, R, R, R, R, R, R, S, S, S, S, T, T, T, T, T, T, U, U, U, U, U, U, V, V, W, W, X, X, Y, Y, Y, Y, Z, Z, ER, ER, CL, CL, IN, IN, TH, TH, QU, QU};


    

    // Update is called once per frame
    void Update()
    {
        
    }
}
