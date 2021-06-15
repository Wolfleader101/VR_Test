using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField] private BaseBullet bullet;
    public BaseBullet Bullet => bullet;

    private Rigidbody _rb;
    
    
    
    //public BaseEntity owner;
    // Start is called before the first frame update
    void Start()
    {
        //_rb = GetComponent<Rigidbody>();
        // rb.velocity = transform.right * bullet.Speed;
        Destroy(gameObject, bullet.DestroyTime);
    }

    private void Update()
    {
        //float angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.GetComponent<BulletHandler>()) return;
        //BaseEntity enemy = hitInfo.GetComponent<BaseEntity>();
        //if (enemy == owner) return;
        
        //if (enemy != null)
        //{
        //    enemy.TakeDamage(damage);

        // }
        Destroy(this.gameObject);
        
    }
}