using UnityEngine;

public class HoverableObject : MonoBehaviour
{
    [SerializeField]float _hoverScale = 1.05f;
    [SerializeField]GameObject _hoverInfo;
    [SerializeField]RectTransform _transform;
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

        bool hovered = Mathf.Abs(delta.x) < _transform.rect.width / 2 && Mathf.Abs(delta.y) < _transform.rect.height / 2;
        if (hovered)
        {
            _transform.localScale = _hoverScale * Vector2.one;
        }
        else
        {
            _transform.localScale = Vector2.one;
        }
        if (_hoverInfo != null)_hoverInfo.SetActive(hovered);
    }
}
