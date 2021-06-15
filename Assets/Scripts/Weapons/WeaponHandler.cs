using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private BaseWeapon weapon;

    public Transform firePoint;
    
    private Vector3 direction;

    private int _currentAmmo = 0;
    private float _currentCooldown;

    private float bulletSpawnedTime;
    private float bulletTravelTime;

    // Start is called before the first frame update
    void Start()
    {
        _currentAmmo = weapon.AmmoCapacity;
        _currentCooldown = weapon.FireRate;
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
        
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
        else if (_currentCooldown <= 0)
        {
            GameObject newBullet = Instantiate(weapon.BulletPrefab, pos, firePoint.rotation);
            StartCoroutine(SpawnBulletCasing(pos));
            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            BulletHandler bulletHandler = newBullet.GetComponent<BulletHandler>();
            bulletRb.AddForce(direction * bulletHandler.Bullet.Speed, ForceMode.Impulse);

             _currentCooldown = weapon.FireRate;
        }
    }

    IEnumerator SpawnBulletCasing(Vector3 pos)
    {
        yield return new WaitForSeconds(0.2f);
        GameObject newBulletCasing = Instantiate(weapon.BulletCasingPrefab, pos, firePoint.rotation);
        StopCoroutine(SpawnBulletCasing(pos));
    }
}