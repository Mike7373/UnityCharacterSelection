using UnityEngine;

public class Bow : Weapon
{
    public readonly float Range;

    public Bow(float range)
    {
        Range = range;
    }

    public void Attack()
    {
        // if (Range > Vector3.Distance(player.position, transform.position))
        // {
        //     Destroy(player.gameObject);
        // }
    }
}
