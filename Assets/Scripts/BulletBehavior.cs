using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed = 2;
    Rigidbody _rigidbody;
    private float _timeAlive = 0;
    // Start is called before the first frame update
    void Start()
    {        
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        _timeAlive += Time.deltaTime;
        if (_timeAlive >= 5)
            Object.Destroy(Bullet);
        _rigidbody.AddForce(transform.forward * BulletSpeed);
        if (_rigidbody.velocity.magnitude > BulletSpeed)
            _rigidbody.velocity = _rigidbody.velocity.normalized * BulletSpeed;
        
    }
}
