using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;
    [SerializeField]SelectableCard[] _selectableCards;
    public Card[] Cards;
    [SerializeField]Slider _expBar;
    [SerializeField]float _expGainSpeed = 20;
    [SerializeField]GameObject _fullTowerMessage;
    [SerializeField]GameObject _skipButton;
    bool _showingCards;

    float _maxExp = 100;
    float _expValue = -1;
    public float Exp
    {
        get { return _expValue; }
        set
        {
            if (value == _expValue) return;
            _expValue = value;

            if (_expValue >= _maxExp)
            {
                _expValue -= _maxExp;
                ShowCards();
            }

            _expBar.value = _expValue / _maxExp;
        }
    }


    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Exp = 0;
    }

    void ShowCards ()
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

        _showingCards = true;
        _skipButton.SetActive(true);
    }

    public void OnCardSelected()
    {
        foreach(SelectableCard sc in _selectableCards)
        {
            sc.gameObject.SetActive(false);
        }
        _showingCards = false;
        _fullTowerMessage.SetActive(false);
        _skipButton.SetActive(false);
    }

    public void OnSelectionRejected ()
    {
        _fullTowerMessage.SetActive(true);
    }

    void Update()
    {
        if (!_showingCards)
        {
            Exp += _expGainSpeed * Time.deltaTime;       
        }

    }
}
