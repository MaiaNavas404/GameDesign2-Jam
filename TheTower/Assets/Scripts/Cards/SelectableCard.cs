using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectableCard : MonoBehaviour
{
    [SerializeField]TMP_Text _floorName;
    [SerializeField]Image _floorImage;
    [SerializeField]TMP_Text _descriptionText;
    int _floorIndex;

    public void SetCard (int n)
    {
        _floorImage.sprite = CardManager.Instance.Cards[n].Sprite;
        _floorName.text = CardManager.Instance.Cards[n].Name;
        _descriptionText.text = CardManager.Instance.Cards[n].Description;

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
