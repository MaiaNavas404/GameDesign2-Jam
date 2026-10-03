using System.Collections.Generic;
using UnityEngine;

public partial class FloorBase : MonoBehaviour
{
    [SerializeField]Transform _graphicsTransf;
    Camera _cam;
    public Tower _tower;
    FloorFSM _fsm;

    [SerializeField]float _hoveredSizeMult = 1.05f;
    [SerializeField]float _draggedSizeMult = 1.1f;
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
        if (_tower.floorAmount > 1)
        {
            _tower.RemoveFloor(gameObject);
        }
    }

    public void SetPosition (int n)
    {
        if (_fsm.CurrentState is not FloorStateDragging && _fsm.CurrentState is not FloorStateHoldDragging) 
            transform.localPosition = new(0, (n + 0.5f) * _graphicsTransf.lossyScale.y, 0);
    }
}
