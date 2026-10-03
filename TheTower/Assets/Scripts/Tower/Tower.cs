using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class Tower : MonoBehaviour
{
    public static Tower Instance;
    [SerializeField]float _cooldownTime;
    [SerializeField]float _triggerTime;
    [SerializeField]int _maxFloors = 4;
    [SerializeField]GameObject _floorObject;
    List<FloorBase> _floors = new();
    [HideInInspector]public int floorAmount => _floors.Count;

    TowerFSM _fsm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _fsm = new(this);

        Instance = this;

        AddFloor(_floorObject);
    }

    public void AddFloor (GameObject floor)
    {
        if (_floors.Count < _maxFloors)
        {
            FloorBase floorScript = Instantiate(floor, transform.position, transform.rotation, transform).GetComponent<FloorBase>();
            _floors.Add(floorScript);
            floorScript.Initialize(this);
            OnFloorsChanged();
        }
    }

    public void RemoveFloor (GameObject floor)
    {
        FloorBase floorScript = floor.GetComponent<FloorBase>();
        if (_floors.Contains(floorScript))
        {
            _floors.Remove(floorScript);
            Destroy(floorScript.gameObject);
            OnFloorsChanged();
        }
    }

    public void OnFloorsChanged ()
    {
        for (int n = 0; n < _floors.Count; n++)
        {
            _floors[n].SetPosition(n);
        }
        _fsm.OnFloorsChanged();
    }

    public void SortTower ()
    {
        List<FloorBase> _sortedFloors = _floors.OrderBy(f => f.transform.position.y).ToList();

        bool orderChanged = false;
        for(int n = 0; n < _floors.Count; n++)
        {
            if (_sortedFloors[n] != _floors[n]) orderChanged = true;
        }

        if (orderChanged)
        {
            _floors = _sortedFloors;
            OnFloorsChanged();
        }
    }

    void Update()
    {
        _fsm.Update(Time.deltaTime);
    }
}
