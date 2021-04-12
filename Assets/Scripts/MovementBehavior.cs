using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    public float Speed = 2.0f;
    public float YMin = -5;
    public float YMax = 4;
    public float StartCos = 0;

    // Start is called before the first frame update
    void Start()
    {
        float yPos = Random.Range(YMin,YMax);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(Speed, 0, 0) * Time.deltaTime;
        StartCos += Time.deltaTime;
        transform.position += new Vector3(0, Mathf.Cos(StartCos), 0) * Speed * Time.deltaTime;
    }
}
