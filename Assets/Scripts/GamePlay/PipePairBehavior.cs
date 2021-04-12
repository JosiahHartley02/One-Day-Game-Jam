using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Change PipePairBehavior so that when the pipes pass a certain point, 
/// they reset their positions to a given spawn point, and set their y 
/// position to a random value
/// </summary>
public class PipePairBehavior : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillPlane"))
            Destroy();
    }
}
/*    public float Speed = 1;
    //Change the distance between pipes in the inspector
    public float DistanceBetweenPipes = 3;
    public float PipePairRespawnPosX = 14;
    public float MinPosY = -8;
    public float MaxPosY = + 6;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = new Rigidbody();
    }

    // Update is called once per frame
    void Update()
    {
        switch(transform.position.x < -PipePairRespawnPosX)
        {
            case true:
                break;
            case false:
                transform.position += new Vector3(-Speed, 0, 0) * Time.deltaTime;
                break;
        }
    }
    public void D*/

