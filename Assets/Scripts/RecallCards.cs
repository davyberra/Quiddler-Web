using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallCards : MonoBehaviour
{
    public GameObject completedCardsPile;
    public GameObject playerHandArea;

    public CardClass[] completedCards;

    public void OnClick()
    {
        completedCards = completedCardsPile.GetComponentsInChildren<CardClass>();
        foreach (CardClass card in completedCards)
        {
            card.transform.SetParent(playerHandArea.transform, false);
        }

    }

}
