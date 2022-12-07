using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private float speedMove;

    int dir = 1;// H??ng
    float _distance = 1;// Kho?ng cách va ch?m

    void Update()
    {
        transform.position += Vector3.right * speedMove * Time.deltaTime * dir;
    }
    void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, Vector2.right * dir, _distance))
        { 
            Debug.Log("Hit something");
            // ??i h??ng
            dir *= -1;
        }
    }
}
