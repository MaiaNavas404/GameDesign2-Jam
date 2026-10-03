using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;
    [SerializeField]SelectableCard[] _selectableCards;
    public Card[] Cards;


    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<int> drawnCards = new();
        for (int i = 0; i < 3; i++)
        {
            int n = -1;
            while (n < 0 || drawnCards.Contains(n))
            {
                n = Random.Range(0, Cards.Length);
            }

            _selectableCards[i].SetCard(n);
            drawnCards.Add(n);
        }
    }

    public void OnCardSelected()
    {
        foreach(SelectableCard sc in _selectableCards)
        {
            sc.gameObject.SetActive(false);
        }
    }
}
