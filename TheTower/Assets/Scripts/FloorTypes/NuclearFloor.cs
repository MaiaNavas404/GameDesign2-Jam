using UnityEngine;

public class NuclearFloor : FloorBase
{
    [SerializeField] private GameObject explosion;
    public override void checkHealth()
    {
        if (_health <= 0)
        {
            if (Tower.Instance.floorAmount > 1)
            {
                Explode();
            }
            else
            {
                GameOver();
            }
        }
    }   
    private void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Sell();
    }

}
