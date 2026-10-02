using UnityEngine;

public partial class FloorBase : MonoBehaviour
{
    [SerializeField]Transform _graphicsTransf;
    Camera _cam;
    Tower _tower;
    FloorFSM _fsm;

    [SerializeField]float _hoveredSizeMult;
    [SerializeField]float _draggedSizeMult;
    [SerializeField]GameObject _hoverInfo;
    bool _isHovered;
    static bool _isDragging;

    InputSystem_Actions _actions;
    Vector2 _mousePos;

    void Awake()
    {
        _fsm = new(this);

        _actions = new();

        _actions.Player.MousePos.performed += ctx => _mousePos = ctx.ReadValue<Vector2>();

        _actions.Player.RightClick.performed += ctx => _fsm.RightClick();
        _actions.Player.LeftClick.performed += ctx => _fsm.LeftClick();
        _actions.Player.LeftClick.canceled += ctx => _fsm.StopLeftClick();

        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
        Vector3 delta = _cam.ScreenToWorldPoint(_mousePos) - transform.position;
        _isHovered = Mathf.Abs(delta.x) < _graphicsTransf.localScale.x / 2 && Mathf.Abs(delta.y) < _graphicsTransf.localScale.y / 2 && !_isDragging;

        _fsm.Update(Time.deltaTime);
    }

    public virtual void Trigger ()
    {
        //Debug.Log(gameObject.name + "  " + Time.time);
    }

    public void Initialize(Tower tower)
    {
        _tower = tower;
    }

    void Sell ()
    {
        _tower.RemoveFloor(gameObject);
    }

    public void SetPosition (int n)
    {
        transform.localPosition = new(0, (n + 0.5f) * _graphicsTransf.lossyScale.y, 0);
    }
}
