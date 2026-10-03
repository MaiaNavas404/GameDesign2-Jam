using UnityEngine;

public class FloorCannon : FloorBase
{
    private GameObject _targetedEnemy;
    [SerializeField] private GameObject cannonBallPrefab;
    public override void Trigger()
    {
        base.Trigger();
        if (Tower.Instance._enemies.Count != 0)
        {
            _targetedEnemy = FindFirstEnemy();
            Attack();
            ActivateSprite();
        }
    }

    private GameObject FindFirstEnemy()
    {
        return Tower.Instance._enemies[0];
    }

    public virtual void Attack()
    {
        ShootCannonBall(cannonBallPrefab);
    }

    public void ShootCannonBall (GameObject cannonBall)
    {
        GameObject newBall = Instantiate(cannonBall,transform.position,Quaternion.identity);
        newBall.transform.rotation =
            LookAt(new Vector2(_targetedEnemy.transform.position.x, _targetedEnemy.transform.position.y));        
    }

    protected Quaternion LookAt(Vector2 point){

        float angle = AngleBetweenPoints(transform.position, point); 
        var targetRotation = Quaternion.Euler (new Vector3(0f,0f,angle +180));
        return targetRotation;
    }
    float AngleBetweenPoints(Vector2 a, Vector2 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
