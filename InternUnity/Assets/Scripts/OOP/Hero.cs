using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    
    [SerializeField] float speedMove;

    public override void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 vecMove = new Vector2(x, y).normalized;

        transform.position += (Vector3)vecMove * speedMove * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<IEnemyHit>().Hit();
            DBController.Instance.AMOUNTCOLLIDE++;
            Debug.Log($"Total collide: { DBController.Instance.AMOUNTCOLLIDE}");
        }
    }
}
