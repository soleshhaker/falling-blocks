using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Block;
    Vector2 screenWidth;
    public Vector2 secondsBeetweenSpawnMinMax;
    public float nextSpawn;

    public Vector2 spawnMinMax;
    public float spawnAngleMax;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn) {
            float secondsToSpawn = Mathf.Lerp(secondsBeetweenSpawnMinMax.y, secondsBeetweenSpawnMinMax.x, Difficulty.GetDiffPercent());
            nextSpawn = Time.time + secondsToSpawn;

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnMinMax.x, spawnMinMax.y);
        Vector2 spawnPosition = new Vector2(Random.Range(-screenWidth.x, screenWidth.x), screenWidth.y + spawnSize);
       GameObject newBlock = (GameObject)Instantiate(Block, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newBlock.transform.localScale = Vector3.one * spawnSize;


        }

    }
   
}
