using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwardMovement : Enemy
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }
}
