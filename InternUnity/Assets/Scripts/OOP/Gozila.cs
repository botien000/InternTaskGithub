using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gozila : Enemy,IEnemyHit
{
    public void Hit()
    {
        Debug.Log("Hit Gozila");
    }

    public override void Skin()
    {
        Debug.Log("Skin Gozila");
    }
}
