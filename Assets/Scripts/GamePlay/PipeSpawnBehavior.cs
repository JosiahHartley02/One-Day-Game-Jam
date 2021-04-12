using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnBehavior : MonoBehaviour
{
    //The lowest y position allowed
    public float YMin;
    //The highest yposition allowed
    public float YMax;
    //Time inbetween spawning a pipe pair
    public float TimeInterval;
    public bool GameOver = false;

    public GameObject PipeRef;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPipes());
    }

    public IEnumerator SpawnPipes()
    {
        float randY = 0;
        while(!GameOver)
        {

            //Find a random spawn position for the pipe
            randY = Random.Range(YMin, YMax);
            Vector3 spawnPosition = new Vector3(transform.position.x, randY, transform.position.z);

            //Spawn in an instance of the pipe prefab at the given position with a default
            GameObject pipe = Instantiate(PipeRef, spawnPosition, new Quaternion());
            //Get the movement component attached to the spawned object
            MovementBehavior movement = pipe.GetComponent<MovementBehavior>();
            //Set the starting cosine to be a random value
            movement.StartCos = Random.Range(-1, 1);

            //Wait for the given time interval before resuming the function
            yield return new WaitForSeconds(TimeInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
