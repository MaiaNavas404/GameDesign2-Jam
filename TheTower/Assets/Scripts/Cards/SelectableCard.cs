using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectableCard : MonoBehaviour
{
    [SerializeField]RectTransform _transform;
    [SerializeField]TMP_Text _floorName;
    [SerializeField]Image _floorImage;
    int _floorIndex;

    bool _isHoveredValue;
    bool _isHovered
    {
        get {return _isHoveredValue;}
        set
        {
            if (value == _isHoveredValue) return;
            _isHoveredValue = value;

            if (value) _transform.localScale = 1.05f * Vector2.one;
            else _transform.localScale = Vector2.one;
        }
    }

    InputSystem_Actions _actions;
    Vector2 _mousePos;

    void Awake()
    {
        _actions = new();

        _actions.Player.MousePos.performed += ctx => _mousePos = ctx.ReadValue<Vector2>();
    }

    void OnEnable()
    {
        _actions.Enable();
    }

    void OnDisable()
    {
        _actions.Disable();
    }

    void Update()
    {
        Vector2 localMousePos = _mousePos - new Vector2(Screen.width / 2, Screen.height / 2);
        Vector2 delta = new Vector2(_transform.localPosition.x, _transform.localPosition.y) - localMousePos;
        _isHovered = Mathf.Abs(delta.x) < _transform.rect.width / 2 && Mathf.Abs(delta.y) < _transform.rect.height / 2;
    }

    public void SetCard (int n)
    {
        _floorImage.sprite = CardManager.Instance.Cards[n].Sprite;
        _floorName.text = CardManager.Instance.Cards[n].Name;

        _floorIndex = n;
    }
    public void OnClicked ()
    {
        Tower.Instance.AddFloor(CardManager.Instance.Cards[_floorIndex].Object);
        CardManager.Instance.OnCardSelected();
    }
}
