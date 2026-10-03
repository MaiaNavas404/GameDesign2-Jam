using UnityEngine;

public class FloorCannon : FloorBase
{
    private GameObject _targetedEnemy;
    [SerializeField] private GameObject cannonBallPrefab;
    public override void Trigger()
    {
        base.Trigger();
        _targetedEnemy = FindFirstEnemy();
        Attack();
        ActivateSprite();
    }

    private GameObject FindFirstEnemy()
    {
        return Tower.Instance._enemies[0];
    }

    private void Attack()
    {
        GameObject newBall;
        Instantiate(cannonBallPrefab,transform.position,Quaternion.LookRotation(_targetedEnemy.transform.position - transform.position));
    }
}
