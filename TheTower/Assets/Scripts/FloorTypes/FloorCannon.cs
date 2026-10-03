using UnityEngine;

public class FloorCannon : FloorBase
{
    private GameObject _targetedEnemy;
    [SerializeField] private GameObject cannonBallPrefab;
    public override void Trigger()
    {
        base.Trigger();
        _targetedEnemy = FindFirstEnemy();
        //Instantiate(cannonBallPrefab,transform.position,Quaternion.LookRotation());

    }

    private GameObject FindFirstEnemy()
    {
        return gameObject;
    }
}
