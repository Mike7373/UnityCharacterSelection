using UnityEngine;

public class Sword : Weapon
{
    public readonly float Strength;

    public Sword(float strength)
    {
        Strength = strength;
    }

    public void Attack()
    {
        // if (Strength > 10)
        // {
        //     Destroy(player.gameObject);
        // }
    }
}
