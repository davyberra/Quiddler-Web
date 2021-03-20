using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject playerHandArea;
    public GameObject faceDownPile;
    public GameObject discardPile;
    public GameObject goDownArea;

    private GameObject[] cardList = GameManager.cardList;
    private List<GameObject> cardDeck = new List<GameObject>();

    public void Start()
    {
        foreach(GameObject card in cardList)
        {
            cardDeck.Add(card);
        }
    }
    public void OnClick()
    {
        GameObject currentCard = cardDeck[Random.Range(0, cardDeck.Count)];
        GameObject playerCard = Instantiate(currentCard, new Vector3(0, 0, 0), Quaternion.identity);
        cardDeck.Remove(currentCard);
        
        playerCard.transform.SetParent(playerHandArea.transform, false);
        
    }
}
