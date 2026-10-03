using System.Collections.Generic;
using UnityEngine;

public class HealthFloor : FloorBase
{
    [SerializeField]float _healAmount;

    public override void Trigger()
    {
        List<FloorBase> floors = Tower.Instance.GetFloors();
        if (floors.Contains(this))
        {
            int index = floors.IndexOf(this);
            if (index + 1 < floors.Count)
            {
                floors[index + 1].TakeDamage(-_healAmount);
            }
        }

        base.Trigger();
    }
}
