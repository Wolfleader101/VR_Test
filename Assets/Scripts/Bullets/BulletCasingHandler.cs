using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCasingHandler : MonoBehaviour
{
    [SerializeField] private BaseBullet bullet;



    //public BaseEntity owner;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bullet.CasingDestroyTime);
    }
}
