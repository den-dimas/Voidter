using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{

    public Bullet bullet;
    public int damage;

    Collider2D area;


    void Start()
    {
        area = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<HitboxComponent>() != null)
        {
            HitboxComponent hitbox = other.GetComponent<HitboxComponent>();

            if (bullet != null)
            {
                hitbox.Damage(bullet.damage);
                return;
            }

            hitbox.Damage(damage);
        }
    }
}
