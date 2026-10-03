using UnityEngine;

public class FloorCannon : FloorBase
{
    private GameObject TargetedEnemy;
    public override void Trigger()
    {
        base.Trigger();
        TargetedEnemy = FindFirstEnemy();
        

    }

    private GameObject FindFirstEnemy()
    {
        return gameObject;
    }
}
