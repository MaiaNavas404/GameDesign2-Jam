using UnityEngine;

public class BuffFloor : FloorBase
{
    public override void Trigger()
    {
        Tower.Instance.TriggerMultiplier = 2;

        base.Trigger();
    }
}
