using UnityEngine;

public class BuffFloor : FloorBase
{
    public override void Awake()
    {
        Tower.Instance.BuffFloorAmount += 1;

        base.Awake();
    }

    public override void OnDestroy()
    {
        Tower.Instance.BuffFloorAmount -= 1;
        //Debug.Log(Tower.Instance.BuffFloorAmount);

        base.OnDestroy();
    }
}
