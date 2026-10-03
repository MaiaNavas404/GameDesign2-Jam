using UnityEngine;

public class SacrificeFloor : FloorCannon
{
    [SerializeField] private float towerDamage = 10;
    public override void Trigger()
    {
        if (FindTowerPosition() != 0)
        {
            if (EnemySpawner.enemies.Count != 0)
            {
                ActivateSprite();
                targetedEnemy = FindFirstEnemy();
                Attack();
                DamageAFloor(FindTowerPosition() -1,towerDamage );
            } 
        }

    }


}
