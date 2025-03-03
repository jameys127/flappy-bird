using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate;
    private float timer = 0;
    public float heightOffset = 10;
    private bool birdIsAlive = true;
    public int spawnAtIncreasedSpeedCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){
            timer += Time.deltaTime;
        } else if(birdIsAlive) {
            SpawnPipe();
            timer = 0;
        }
        
    }

    void SpawnPipe(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        GameObject instantiatedPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        if(spawnAtIncreasedSpeedCounter >= 1){
            instantiatedPipe.GetComponent<PipeMoveScript>().IncreaseSpeed(spawnAtIncreasedSpeedCounter);
        }
    }

    public void IncreaseSpeedCounter(){
        spawnAtIncreasedSpeedCounter++;
    }

    public void BirdDied(){
        birdIsAlive = false;
    }
    
}
