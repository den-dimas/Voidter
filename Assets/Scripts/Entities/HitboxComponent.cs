using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField]
    HealthComponent health;

    Collider2D area;


    void Start()
    {
        area = GetComponent<Collider2D>();
    }

    public void Damage(Bullet bullet)
    {
        if (health != null)
            health.Subtract(bullet.damage);
    }

    public void Damage(int damage)
    {
        if (health != null)
            health.Subtract(damage);
    }
}
