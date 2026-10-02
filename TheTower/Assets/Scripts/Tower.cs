using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]int _maxFloors = 4;
    [SerializeField]GameObject _floorObject;
    [SerializeField]GameObject _floorObject2;
    List<FloorBase> _floors = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddFloor(_floorObject);
        AddFloor(_floorObject2);
        AddFloor(_floorObject);
        AddFloor(_floorObject2);
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

    void OnFloorsChanged ()
    {
        for (int n = 0; n < _floors.Count; n++)
        {
            _floors[n].SetPosition(n);
        }
    }
}
