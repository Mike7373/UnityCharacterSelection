using System;
using Random = UnityEngine.Random;

[Serializable]
public struct Stats
{
    public int strength;
    public int health;
    public int speed;
    public int magicPower;

    //Inizialmente avevo pensato di farle random, ma poi ho deciso di farle scegliere al designer :)
    public void SetRandomStats()
    {
        strength = Random.Range(1, 20);
        health = Random.Range(50, 200);
        speed = Random.Range(10, 30);
        magicPower = Random.Range(1, 20);
    }
}