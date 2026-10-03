using UnityEngine;

public class GambleFloor : FloorCannon
{
    [SerializeField]GameObject _bigCannonBallPrefab;

    public override void Attack()
    {
        float random = Random.value;
        if (random < 0.8)
        {
            base.Attack();
        }
        else
        {
            ShootCannonBall(_bigCannonBallPrefab);
        }
    }
}
