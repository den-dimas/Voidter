using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetPlayer : MonoBehaviour
{
    public float speed = 4f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(speed * Time.deltaTime * direction);
        }
    }
}
