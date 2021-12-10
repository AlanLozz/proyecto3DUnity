using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
  public GameObject[] obstaclePrefab;
  private Vector3 spawnPos = new Vector3(25, 0, 0);
  private float startDelay = 2;
  private float repeatRate = 2;
  private PlayerController playerControllerScript;
  // Start is called before the first frame update
  void Start()
  {
    InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    playerControllerScript = GameObject.Find("Punk").GetComponent<PlayerController>();
  }
  void SpawnObstacle()
  {
    if (playerControllerScript.gameOver == false)
    {
      int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
      Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
    }
  }

  // Update is called once per frame
  void Update() { }
}
