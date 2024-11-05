using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20;
    public int damage = 10;


    public IObjectPool<Bullet> objectPool;

    Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        rb.velocity = bulletSpeed * Time.deltaTime * Vector2.up;
    }

    private void Update()
    {
        Vector2 ppos = Camera.main.WorldToViewportPoint(transform.position);

        if (ppos.y > 1.01f)
        {
            objectPool.Release(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Damage enemy
            other.gameObject.GetComponent<HitboxComponent>().Damage(this);
            objectPool.Release(this);
        }
    }
}
