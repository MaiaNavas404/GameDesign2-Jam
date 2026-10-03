using UnityEngine;

public class PotientalFloor : FloorCannon
{
    private int _towerLevel = 0;
    public virtual void ShootCannonBall (GameObject cannonBall)
    {
        GameObject newBall = Instantiate(cannonBall,transform.position,Quaternion.identity);
        newBall.transform.rotation =
            LookAt(new Vector2(targetedEnemy.transform.position.x, targetedEnemy.transform.position.y));
        newBall.GetComponent<PotientalBall>().level = _towerLevel;
        _towerLevel++;
    }
}
