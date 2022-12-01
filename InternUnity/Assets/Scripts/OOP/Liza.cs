using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liza : Enemy,IEnemyHit
{
    public void Hit()
    {
        Debug.Log("Hit Liza");
    }

    public override void Skin()
    {
        Debug.Log("Skin Liza");
    }
}
