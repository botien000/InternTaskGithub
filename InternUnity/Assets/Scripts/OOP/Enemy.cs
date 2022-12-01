using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{

    [SerializeField] float speedMove;
    [SerializeField] Transform[] transfMoveTo;


    int randomIndex;

    int preRandomIndex;

    private void Start()
    {
        randomIndex = Random.Range(0, 4);
        preRandomIndex = randomIndex;
    }
    public override void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, transfMoveTo[randomIndex].position, speedMove * Time.deltaTime);
        if(transform.position == transfMoveTo[randomIndex].position)
        {
            while (preRandomIndex == randomIndex)
            {
                randomIndex = Random.Range(0, 4);
            }
            preRandomIndex = randomIndex;
        }
    }

    public abstract void Skin();
}
