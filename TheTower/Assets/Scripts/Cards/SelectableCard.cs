using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectableCard : MonoBehaviour
{
    [SerializeField]TMP_Text _floorName;
    [SerializeField]Image _floorImage;
    int _floorIndex;

    public void SetCard (int n)
    {
        _floorImage.sprite = CardManager.Instance.Cards[n].Sprite;
        _floorName.text = CardManager.Instance.Cards[n].Name;

        _floorIndex = n;

        gameObject.SetActive(true);
    }
    public void OnClicked ()
    {
        if (Tower.Instance.AddFloor(CardManager.Instance.Cards[_floorIndex].Object))
        {
            CardManager.Instance.OnCardSelected();
        }
        else
        {
            CardManager.Instance.OnSelectionRejected();
        }
    }
}
