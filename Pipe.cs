using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private int _speed;
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.left * _speed * Time.fixedDeltaTime ;
    }
    
    
}
