using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy,IEnemyHit
{
    public void Hit()
    {
        Debug.Log("Hit Zombie");
    }

    public override void Skin()
    {
        Debug.Log("Skin Zombie");
    }
}
