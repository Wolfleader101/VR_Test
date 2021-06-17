using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletCasingHandler : MonoBehaviour
{
    [SerializeField] private BaseBullet bullet;

    
    public ObjectPool<GameObject> bulletCasingPool;


    //public BaseEntity owner;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(ReleaseBulletCasingAfterTime());
    }
    
    IEnumerator ReleaseBulletCasingAfterTime()
    {
        yield return new WaitForSeconds(bullet.CasingDestroyTime);
        bulletCasingPool.Release(this.gameObject);
        StopCoroutine(ReleaseBulletCasingAfterTime());
    }
}
