using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] float shootIntervalInSeconds = 3f;


    [Header("Bullets")]
    public Bullet bullet;

    public Transform parentTransform;


    private float timer;


    private void Shoot()
    {
        GameObject obj = GameObject.Find("BulletSpawnPoint");
        Instantiate(bullet, obj.transform.position, obj.transform.parent.transform.rotation, obj.transform);
    }


    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= shootIntervalInSeconds)
        {
            timer = 0;
            Shoot();
        }
    }
}
