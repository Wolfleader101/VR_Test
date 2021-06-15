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

    [SerializeField] private WeaponHandler weapon;
    public WeaponHandler Weapon => weapon;
    
    
    // Start is called before the first frame update
    void Start()
    {
        weapon = this.GetComponentInChildren<WeaponHandler>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (shootAction != null && shootAction.action != null && shootAction.action.enabled && shootAction.action.controls.Count > 0)
        {
            if (shootAction.action.activeControl != null)
            {
                weapon.Shoot();
                //typeToUse = shootAction.action.activeControl.valueType;
            }
        }
    }
}
