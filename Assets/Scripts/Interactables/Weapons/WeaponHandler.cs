using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;

public class WeaponHandler : MonoBehaviour
{
   
    
    [SerializeField] private BaseWeapon weapon;
    
    public Transform firePoint;
    public Transform casingPoint;

    private Vector3 direction;

    private int _currentAmmo = 0;
    private float _currentCooldown;

    private float bulletSpawnedTime;
    private float bulletTravelTime;

    private ObjectPool<GameObject> _bulletPool;
    private ObjectPool<GameObject> _bulletCasingPool;

    // Start is called before the first frame update
    void Start()
    {
        _currentAmmo = weapon.AmmoCapacity;
        _currentCooldown = weapon.FireRate;
        
        _bulletPool = new ObjectPool<GameObject>(createFunc: () => Instantiate(weapon.BulletPrefab),
            actionOnGet: (obj) => obj.SetActive(true), actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj), collectionCheck: false, 
            defaultCapacity: weapon.AmmoCapacity, maxSize:
            (weapon.AmmoCapacity * 2));
        
        _bulletCasingPool = new ObjectPool<GameObject>(createFunc: () => Instantiate(weapon.BulletCasingPrefab),
            actionOnGet: (obj) => obj.SetActive(true), actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj), collectionCheck: false, 
            defaultCapacity: weapon.AmmoCapacity, maxSize:
            (weapon.AmmoCapacity * 2));
        
        // to dispose of a pool
        // _bulletPool.Dispose();
        
    }

    // Update is called once per frame
    void Update()
    {
        //  Shoot();
        Vector2 gunPosition = transform.position;
        bulletTravelTime = Time.time - bulletSpawnedTime;
        direction = firePoint.forward;
    }

    public void Shoot()
    {
        Vector3 pos = firePoint.position;
        Vector3 casingPos = casingPoint.position;

        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
        else if (_currentCooldown <= 0)
        {
            CreateBullet(pos);
            CreateBulletCasing(casingPos);

            // reset cooldown
            _currentCooldown = weapon.FireRate;
        }
    }
    
    void CreateBullet(Vector3 pos)
    {
        GameObject newBullet = _bulletPool.Get();
        BulletHandler bulletHandler = newBullet.GetComponent<BulletHandler>();
        Transform bulletTransform = newBullet.GetComponent<Transform>();
        Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            
        // set its rotation and pos
        bulletTransform.position = pos;
        bulletTransform.rotation = quaternion.Euler(float3.zero);
        bulletTransform.rotation = firePoint.rotation;

        // reset its velocity
        bulletRb.velocity = new Vector3();
        
        //provide it with the bullet pool
        bulletHandler.bulletPool = _bulletPool;
            
        // move bullet
        bulletRb.AddForce(direction * bulletHandler.Bullet.Speed, ForceMode.Impulse);
    }

    void CreateBulletCasing(Vector3 casingPos)
    {
        // create bullet casing
        GameObject newBulletCasing = _bulletCasingPool.Get();
        BulletCasingHandler bulletCasingHandler = newBulletCasing.GetComponent<BulletCasingHandler>();
        Transform bulletCasingTransform = newBulletCasing.GetComponent<Transform>();
        Rigidbody bulletCasingRb = newBulletCasing.GetComponent<Rigidbody>();
            
        // set rotation and position
        bulletCasingTransform.position = casingPos;
        bulletCasingTransform.rotation = casingPoint.rotation;
        
        // reset its velocity
        bulletCasingRb.velocity = new Vector3();
        
        // set bullet casing pool
        bulletCasingHandler.bulletCasingPool = _bulletCasingPool;
            
        // add force to bullet to make it fling off
        bulletCasingRb.AddForce(casingPoint.up * 5, ForceMode.Impulse);
    }


    
}