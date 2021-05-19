using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 ShootDir;
    private float moveSpeed = 100f;
    public void Setup(Vector3 shootDir)
    {
        this.ShootDir = shootDir;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(shootDir * moveSpeed, ForceMode.Impulse);
        Destroy(gameObject, 7);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
