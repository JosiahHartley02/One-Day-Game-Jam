using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapBehavior : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float CameraRotation = 1;
    public float RotationSpeed = 1;

    public GameObject BulletRef;
    private Rigidbody _rigidbody;
    public GameObject child;

    float previousMousePosition = Input.mousePosition.x;
    float _rotateVal = 1;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);

        child.transform.parent = transform; 
    }
    // Update is called once per frame
    void Update()
    {
        //Apply a stopping force
        if (_rigidbody.velocity.magnitude > 0)
            _rigidbody.AddForce(new Vector3(-_rigidbody.velocity.x * .10f - 0.1f, -_rigidbody.velocity.y * .10f - 0.1f, -_rigidbody.velocity.z * .10f - 0.1f));
        else if (_rigidbody.velocity.magnitude < 0)
            _rigidbody.AddForce(new Vector3(_rigidbody.velocity.x * .10f + 0.1f, _rigidbody.velocity.y * .10f + 0.1f, _rigidbody.velocity.z * .10f + 0.1f));
        
        //Rotating the worm
        float mouseDisplacement = Input.mousePosition.x - previousMousePosition;
        previousMousePosition = Input.mousePosition.x;
        if (mouseDisplacement == 0)
            _rotateVal = 0;
        else
            _rotateVal = (mouseDisplacement / Mathf.Abs(mouseDisplacement));

        transform.Rotate(new Vector3(0, 1, 0), _rotateVal * RotationSpeed);

        //Moving Forward And BackWard
        if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
        {
            _rigidbody.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * MovementSpeed, ForceMode.Impulse);
        }
        else if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0)
        {
            _rigidbody.AddForce(new Vector3(-transform.forward.x, 0, -transform.forward.z) * MovementSpeed, ForceMode.Impulse);
        }

        //Moving Right and Left
        if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            _rigidbody.AddForce(new Vector3(transform.forward.z, 0, -transform.forward.x) * MovementSpeed, ForceMode.Impulse);
        }
        else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            _rigidbody.AddForce(new Vector3(-transform.forward.z, 0, transform.forward.x) * MovementSpeed, ForceMode.Impulse);
        }

        //Shoot the bullet
        if (Input.GetButtonDown("Jump"))
        {
            //Spawn in an instance of the pipe prefab at the given position with a default
            GameObject bullet = Instantiate(BulletRef, transform.position, new Quaternion());
            //Get the movement component attached to the spawned object
            BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
            //set the bullets forward direction
            bullet.transform.forward = transform.forward;
            bullet.transform.position = transform.position;
        }

        //Cap the movement speed
        if (_rigidbody.velocity.magnitude > MovementSpeed)
            _rigidbody.velocity = _rigidbody.velocity.normalized * MovementSpeed;
    }
}
