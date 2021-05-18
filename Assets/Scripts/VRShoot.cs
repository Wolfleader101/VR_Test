using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

public class VRShoot : MonoBehaviour
{
    [SerializeField] private InputActionReference shootAction;
    public InputActionReference ShootAction => shootAction;
    public GameObject Bullet;
    private float _currentCooldown;
    Type _lastActiveType = null;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentCooldown = 0.1f;
    }
    

    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.forward * 1.2f;
        
        if (shootAction != null && shootAction.action != null && shootAction.action.enabled && shootAction.action.controls.Count > 0)
        {

           // Type typeToUse = null;

            if (shootAction.action.activeControl != null)
            {
                if (_currentCooldown > 0)
                {
                    _currentCooldown -= Time.deltaTime;
                }
                else if (_currentCooldown <= 0)
                {
                    GameObject newBullet = Instantiate(Bullet, pos, transform.rotation);
                    var bullet_rb = newBullet.GetComponent<Rigidbody>();
                    bullet_rb.AddForce(newBullet.transform.forward * 2);
             
                    _currentCooldown = 0.1f;
                }
                
                //typeToUse = shootAction.action.activeControl.valueType;
            }
            // else
            // {
            //     typeToUse = _lastActiveType;
            // }
            //
            // if(typeToUse == typeof(bool))
            // {
            //     _lastActiveType = typeof(bool);
            //     bool value = shootAction.action.ReadValue<bool>();
            //     Debug.Log("BOOL TEST");
            // }
            // else if(typeToUse == typeof(float))
            // {
            //     _lastActiveType = typeof(float);
            //     float value = shootAction.action.ReadValue<float>();
            //     if (value > 0.5)
            //         Debug.Log("FLOAT TEST");
            // }
        }
    }
}
