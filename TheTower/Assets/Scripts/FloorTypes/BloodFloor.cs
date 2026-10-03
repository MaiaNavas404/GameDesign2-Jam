using Unity.Mathematics;
using UnityEngine;

public class BloodFloor : FloorCannon
{
    private int _towerLevel = 0;
    public override void ShootCannonBall (GameObject cannonBall)
    {
        CalculateLevel();
        GameObject newBall = Instantiate(cannonBall,transform.position,Quaternion.identity);
        newBall.transform.rotation =
            LookAt(new Vector2(targetedEnemy.transform.position.x, targetedEnemy.transform.position.y));
        newBall.GetComponent<PotientalBall>().level = _towerLevel;
       
    }

    private void CalculateLevel()
    {
        _towerLevel = Mathf.FloorToInt( _maxHealth/_health) - 1;
    }
}
