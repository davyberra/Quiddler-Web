using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{
    public GameObject completedCardsPile;
    public GameObject playerHandArea;
    public GameObject goDownPile;
    public GameObject finishedCardsPile;
    public Component[] cardsCompleted;
    public Component[] playerCards;
    public Component[] goDownCards;


    public void OnClick()
    {
        cardsCompleted = completedCardsPile.GetComponentsInChildren<CardClass>();
        playerCards = playerHandArea.GetComponentsInChildren<CardClass>();
        goDownCards = goDownPile.GetComponentsInChildren<CardClass>();

        foreach (CardClass card in cardsCompleted)
        {
            card.transform.SetParent(finishedCardsPile.transform, false);
        }


    }
}
