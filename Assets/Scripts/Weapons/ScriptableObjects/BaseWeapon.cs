using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Weapon")]
public class BaseWeapon : ScriptableObject
{
    [SerializeField] private int ammoCapacity = 10;
    public int AmmoCapacity => ammoCapacity;
    
    [SerializeField] private float fireRate = 1; // fire rate in seconds. (how often to shoot)
    public float FireRate => fireRate;

    [SerializeField] private float reloadTime = 2.3f;
    public float ReloadTime => reloadTime;

    [SerializeField] private GameObject bulletPrefab;
    public GameObject BulletPrefab => bulletPrefab;
    
}