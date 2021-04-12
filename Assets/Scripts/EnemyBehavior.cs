using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject PlayerRef;
    public float speed = 1;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //find the direction to the player
        Vector3 direction = (
        GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
        //go that way
        transform.position += (direction * speed) * Time.deltaTime;

        transform.forward = direction;

        if (_rigidbody.velocity.magnitude > speed)
            _rigidbody.velocity = _rigidbody.velocity.normalized * speed;
    }
}
