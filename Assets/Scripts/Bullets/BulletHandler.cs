using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletHandler : MonoBehaviour
{
    [SerializeField] private BaseBullet bullet;
    public BaseBullet Bullet => bullet;

    public ObjectPool<GameObject> bulletPool;

    //private Rigidbody _rb;
    
    
    
    //public BaseEntity owner;
    // Start is called before the first frame update
    void OnEnable()
    {
        //_rb = GetComponent<Rigidbody>();
        // rb.velocity = transform.right * bullet.Speed;
        //Destroy(gameObject, bullet.DestroyTime);
        StartCoroutine(ReleaseBulletAfterTime());
    }

    private void Update()
    {
        //float angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    IEnumerator ReleaseBulletAfterTime()
    {
        yield return new WaitForSeconds(bullet.DestroyTime);
        bulletPool.Release(this.gameObject);
        StopCoroutine(ReleaseBulletAfterTime());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletHandler>()) return;
        
        bulletPool.Release(this.gameObject);
        //Destroy(this.gameObject);

    }
}