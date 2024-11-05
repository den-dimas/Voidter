using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds = 3f;


    [Header("Bullets")]
    public Bullet bullet;
    private IObjectPool<Bullet> objectPool;

    private bool collectionCheck = true;

    private int defaultCapacity = 20;
    private int maxSize = 50;

    public Transform parentTransform;


    private float timer;

    private void Awake()
    {
        objectPool = new ObjectPool<Bullet>(CreateBullet, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
    }


    private void Shoot()
    {
        Bullet bulletObj = objectPool.Get();
        GameObject obj = GameObject.Find("BulletSpawnPoint");

        bulletObj.transform.SetPositionAndRotation(obj.transform.position, obj.transform.rotation);
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

    private Bullet CreateBullet()
    {
        Bullet instance = Instantiate(bullet);
        instance.objectPool = objectPool;
        instance.transform.parent = transform;

        return instance;
    }

    private void OnGetFromPool(Bullet obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(Bullet obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(Bullet obj)
    {
        Destroy(obj.gameObject);
    }
}
