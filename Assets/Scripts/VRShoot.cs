using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public class VRShoot : MonoBehaviour
{
    [SerializeField] private InputActionReference shootAction;
    public InputActionReference ShootAction => shootAction;

    [SerializeField] private Transform firePoint;
    public Transform FirePoint => firePoint;

    public GameObject Bullet;
    private float _currentCooldown;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _currentCooldown = 0.1f;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (shootAction != null && shootAction.action != null && shootAction.action.enabled && shootAction.action.controls.Count > 0)
        {
            if (shootAction.action.activeControl != null)
            {
                if (_currentCooldown > 0)
                {
                    _currentCooldown -= Time.deltaTime;
                }
                else if (_currentCooldown <= 0)
                {
                    GameObject newBullet = Instantiate(Bullet, firePoint.position, quaternion.identity);
                    Vector3 shootDir = firePoint.forward;
                    newBullet.GetComponent<Bullet>().Setup(shootDir);

                    _currentCooldown = 0.1f;
                }
                
                //typeToUse = shootAction.action.activeControl.valueType;
            }
        }
    }
}
